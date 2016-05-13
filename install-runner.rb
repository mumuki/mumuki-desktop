#!/usr/bin/env ruby

require "optparse"
load "languages_local.rb"
load "languages_sql.rb"

INSTALL_SCRIPT = <<-EOF
  git submodule update --init --recursive
  bundle install
EOF

$local = LocalIndex.new
$sql = SqlIndex.new

# Installs a language on the machine
# (it must exist in the database)
def install(language_name)
  $sql.get_language(language_name) { |language, repo_url|
    if $local.is_installed? language_name
      abort "The language '#{language_name} is already installed."
    end

    puts "Installing '#{language_name}'..."
    success = system <<-EOF
      function ifFailed {
        local status=$?
        if [ $status -ne 0 ]; then
          echo $1
          cd
          rm -rf #{language_name}
          exit $status
        fi
      }
      cd

      git clone #{repo_url} #{language_name}
      ifFailed "Unable to clone the language repository!"

      cd #{language_name}
      #{INSTALL_SCRIPT}
      ifFailed "The install command has exploded!"

      if [ -f escualo_install.sh ]; then
        echo "Deploy script found! Running..."

        bash escualo_install.sh
        ifFailed "The deploy script has exploded!"
      fi
    EOF
    if not success then abort end

    port = $local.add_language! language_name
    update

    puts "The language '#{language_name}' was installed and now it runs on port #{port}!"
  }
end

# Uninstalls a language from the machine
def uninstall(language_name)
  $sql.get_language(language_name) { |language, repo_url|
    if not $local.is_installed? language_name
      abort "The language '#{language_name} is not installed yet."
    end

    puts "Uninstalling '#{language_name}'..."
    success = system <<-EOF
      cd
      rm -rf #{language_name}
    EOF
    if not success then abort end

    $local.remove_language! language_name
    update

    puts "The language '#{language_name}' was uninstalled!"
  }
end

# Updates the languages sql table.
def update
  $sql.update_languages_table $local.info
end

# Displays the help on stdout
def show_help
  puts "Examples:"
  puts "./install-runner.rb --install gobstones"
  puts "./install-runner.rb --uninstall haskell"
  puts "./install-runner.rb --update"
  abort
end

# ---

OptionParser.new do |opt|
  opt.on("--help") { show_help }
  opt.on("--install LANGUAGE") { |it| install it }
  opt.on("--uninstall LANGUAGE") { |it| uninstall it }
  opt.on("--update") { update }
end.parse!
