Vagrant.configure(2) do |config|
  config.vm.box = "ubuntu/trusty64"

  config.vm.box_check_update = false # `vagrant box outdated` to update

  config.vm.network "forwarded_port", guest: 3000, host: 3000

  config.vm.provision "shell", path: "install-atheneum.sh" # this runs only the first time

  # config.vm.synced_folder "htdocs", "/var/www/html"
end
