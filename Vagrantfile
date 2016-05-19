Vagrant.configure(2) do |config|
  config.vm.box = "ubuntu/trusty64"

  config.vm.box_check_update = false
  # (`vagrant box outdated` to update)

  config.vm.network "forwarded_port", guest: 3000, host: 3000

  config.vm.provider "virtualbox" do |vb|
    vb.memory = "2048"
  end

  timeout_for_updates = 10 # max time to wait for internet connection
  config.vm.provision "shell",
    name: "Update and start",
    inline: "cd /home/vagrant && ./stop.sh && ./update.rb #{timeout_for_updates} && ./run.rb",
    privileged: false
end
