#!/usr/bin/env ruby

load "languages_local.rb"

wait_file = <<-EOF
  wait_file() {
    local file="$1"; shift
    local wait_seconds="${1:-10}"; shift # 10 seconds as default timeout

    until test $((wait_seconds--)) -eq 0 -o -f "$file" ; do sleep 1; done

    ((++wait_seconds))
  }
EOF

wait_30_seconds = <<-EOF
  wait_file "$server_pid" 30 || {
    echo "Server pid file missing after waiting for 30 seconds: '$server_pid'"
    exit 1
  }
EOF

system '(cd ~ && exec ./start-atheneum.sh) &'
LocalIndex.new.info["languages"].each do |language|
  system <<-EOF
    #{wait_file}
    (cd ~/#{language["name"]} && rm -f rack.pid && exec bundle exec rackup -p#{language["port"]} -P rack.pid) &

    server_pid=~/#{language["name"]}/rack.pid

    #{wait_30_seconds}
    echo ">>>>> Runner #{language["name"]} started!"
  EOF
end

system <<-EOF
  #{wait_file}

  server_pid=~/mumuki-atheneum/tmp/pids/server.pid
  #{wait_30_seconds}
  echo ">>>>> Atheneum started!"
EOF
