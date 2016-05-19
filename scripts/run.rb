#!/usr/bin/env ruby

load "languages_local.rb"

wait_port = <<-EOF
  wait_port() {
    local port="$1"; shift
    local wait_seconds="${1:-10}"; shift # 10 seconds as default timeout

    until nc -z localhost "$port" ; do sleep 1; done

    ((++wait_seconds))
  }

  wait_30_seconds_for() {
    wait_port "$1" 30 || {
      echo "Server unreachable on port $server_port after waiting for 30 seconds."
      exit 1
    }
  }
EOF

system '(cd ~ && exec ./start-atheneum.sh) &'
LocalIndex.new.info["languages"].each do |language|
  system <<-EOF
    #{wait_port}
    (cd ~/#{language["name"]} && exec bundle exec rackup -p#{language["port"]}) &

    wait_30_seconds_for #{language["port"]}
    echo ">>>>> Runner #{language["name"]} started!"
  EOF
end

system <<-EOF
  #{wait_port}
  wait_30_seconds_for 3000
  echo ">>>>> Atheneum started!"
EOF
