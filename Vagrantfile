# -*- mode: ruby -*-
# vi: set ft=ruby :

Vagrant.configure(2) do |config|
  # Disable automatic box update checking. If you disable this, then
  # boxes will only be checked for updates when the user runs
  # `vagrant box outdated`.
  config.vm.box_check_update = false

  config.vm.box = "ubuntu/trusty64"
  config.vm.network "forwarded_port", guest: 3000, host: 3000
  # config.vm.synced_folder "htdocs", "/var/www/html"
end

# --------------
# OTHER OPTIONS:
# --------------

# # Provider-specific configuration so you can fine-tune various
# # backing providers for Vagrant. These expose provider-specific options.
# # Example for VirtualBox:
#
# config.vm.provider "virtualbox" do |vb|
#   # Display the VirtualBox GUI when booting the machine
#   vb.gui = true
#
#   # Customize the amount of memory on the VM:
#   vb.memory = "1024"
# end

# # Enable provisioning with a shell script. Additional provisioners such as
# # Puppet, Chef, Ansible, Salt, and Docker are also available. Please see the
# # documentation for more information about their specific syntax and use.
# config.vm.provision "shell", inline: <<-SHELL
#   sudo apt-get update
#   sudo apt-get install -y apache2
# SHELL
# # or with a file...
# config.vm.provision "shell", path: "config.sh"