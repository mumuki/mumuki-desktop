#!/usr/bin/env ruby

require "optparse"
load "repos.rb"
load "languages_index.rb"
load "languages_sql.rb"

INSTALL_SCRIPT = ".mumuki-offline/install.sh"

# Installs a language on the machine
# (it must exist in the database)
def install(language_name)
  get_languages { |languages|
    language = languages.find { |it| it["name"] == language_name }
    repo_url = repos[language_name]

    if is_installed language_name
      abort "The language '#{language_name} is already installed."
    end
    if language.nil?
      abort "The language '#{language_name}' wasn't found. Did you run `rake db:seed`?"
    end
    if repo_url.nil?
      abort "Missing repository url for '#{language_name}'."
    end

    puts "Installing '#{language_name}'..."
    success = system <<-EOF
      cd
      git clone #{repo_url} #{language_name}
      if [ $? -ne 0 ]; then
        echo "Unable to clone the language repository!"
        exit 1
      fi

      cd #{language_name}
      if [ ! -f #{INSTALL_SCRIPT} ]; then
        echo "Installer not found."
        exit 1
      fi

      bash #{INSTALL_SCRIPT}
      if [ $? -ne 0 ]; then
        echo "The installer has exploded!"
        exit 1
      fi
    EOF
    if not success then abort end

    port = add_language_to_index language_name
    add_language_to_database language["id"], port

    puts "The language '#{language_name}' was installed and now it runs on port #{port}!"
  }
end

# Displays the help on stdout
def show_help
  puts "Examples:"
  puts "./install-runner.rb --install haskell"
  puts "./install-runner.rb --remove gobstones"
  abort
end

# ---

OptionParser.new do |opt|
  opt.on("--help") { show_help }
  opt.on("--install LANGUAGE") { |it| install it }
  opt.on("--uninstall LASTNAME") { |it| uninstall it }
end.parse!
