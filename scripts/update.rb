#!/usr/bin/env ruby

load "languages_local.rb"
timeout = ARGV[0] || 10 # default timeout

puts "Checking for updates..."
doIHaveInternet = system <<-EOF
  wget -q --tries=10 --timeout=#{timeout} --spider http://google.com
EOF

needPull = <<-EOF
  function needPull {
    LOCAL=$(git rev-parse @)
    REMOTE=$(git rev-parse @{u})
    BASE=$(git merge-base @ @{u})

    if [ $LOCAL = $REMOTE ]; then
      return 1
    elif [ $LOCAL = $BASE ]; then
      return 0 # true
    elif [ $REMOTE = $BASE ]; then
      return 1
    else
      return 1
    fi
  }
EOF


if doIHaveInternet
  puts "Updating atheneo..."
  system <<-EOF
    #{needPull}

    cd ~/mumuki-atheneum
    . ../env.sh
    git remote update
    if needPull; then
      git pull
      bundle install
      rake db:migrate db:seed
      rake assets:precompile
    else
      echo "No need to update."
    fi
  EOF

  LocalIndex.new.info["languages"].each do |language|
    puts "Updating language #{language['name']}..."
    system <<-EOF
      #{needPull}

      cd ~/#{language['name']}
      git remote update
      if needPull; then
        git pull
        bundle install
      else
        echo "No need to update."
      fi
    EOF
  end

  puts "Update finished."
else
  puts "No internet connection detected! Update canceled."
end
