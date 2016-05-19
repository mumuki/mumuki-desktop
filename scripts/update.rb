#!/usr/bin/env ruby

load "languages_local.rb"
timeout = ARGV[0] || 10 # default timeout

puts "Checking for updates..."
doIHaveInternet = system <<-EOF
  wget -q --tries=10 --timeout=#{timeout} --spider http://google.com
EOF

if doIHaveInternet
  puts "Updating atheneo..."
  system 'cd ~/mumuki-atheneum && exec git pull && exec rake db:seed'
  LocalIndex.new.info["languages"].each do |language|
    puts "Updating language #{language['name']}..."
    system "cd ~/#{language['name']} && exec git pull"
  end
  puts "Update finished."
else
  puts "No internet connection detected! Updated canceled."
end
