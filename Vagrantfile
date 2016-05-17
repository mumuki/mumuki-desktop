Vagrant.configure(2) do |config|
  config.vm.box = "ubuntu/trusty64"

  config.vm.box_check_update = false
  # (`vagrant box outdated` to update)

  config.vm.network "forwarded_port", guest: 3000, host: 3000

  config.vm.provider "virtualbox" do |vb|
    vb.memory = "2048"
  end

  config.vm.provision "shell",
    name: "Start server",
    inline: 'cd /home/vagrant && ./stop.sh && ./run.rb',
    privileged: false
end
