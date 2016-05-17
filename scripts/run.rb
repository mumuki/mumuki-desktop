#!/usr/bin/env ruby

load "languages_local.rb"

system '(cd ~ && exec ./start-atheneum.sh) &'
LocalIndex.new.info["languages"].each do |language|
  system <<-EOF
    (cd ~/#{language["name"]} && exec bundle exec rackup -p#{language["port"]}) &
  EOF
end

system <<-EOF
  wait_file() {
    local file="$1"; shift
    local wait_seconds="${1:-10}"; shift # 10 seconds as default timeout

    until test $((wait_seconds--)) -eq 0 -o -f "$file" ; do sleep 1; done

    ((++wait_seconds))
  }

  server_pid=~/mumuki-atheneum/tmp/pids/server.pid
  wait_file "$server_pid" 30 || {
    echo "Server pid file missing after waiting for 30 seconds: '$server_pid'"
    exit 1
  }

  echo "Server started!"
EOF
