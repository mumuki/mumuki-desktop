#!/usr/bin/env ruby

load "languages_local.rb"

system '(cd ~/mumuki-atheneum && exec ./start_offline.sh) &'
LocalIndex.new.info["languages"].each do |language|
  system <<-EOF
    (cd #{language["name"]} && sudo exec bundle exec rackup -p#{language["port"]}) &
  EOF
end
