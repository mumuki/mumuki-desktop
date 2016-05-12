#!/usr/bin/env ruby

load "languages_local.rb"

system '(cd ~/mumuki-atheneum ; ./start_offline.sh) &'
LocalIndex.new.info["languages"].each do |language|
  system <<-EOF
    (cd #{language["name"]} ; bundle exec rackup -p#{language["port"]}) &
  EOF
end
