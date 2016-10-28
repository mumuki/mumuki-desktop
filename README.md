# mumuki-offline

This repository contains the scripts and assets needed to install a standalone version of Mumuki. It runs inside a virtual machine, so [Vagrant](https://www.vagrantup.com/downloads.html) and [VirtualBox](https://www.virtualbox.org/wiki/Downloads) should be installed on the target machine.

## Creating the virtual machine

Before installing Mumuki offline, you need to generate the virtual machine with the language runners you want (they can be modified afterwards). For this step, you will need a stable internet connection, because many heavy things are downloaded.

Follow these steps to create the box:

```bash
# 1 - create the VM:
vagrant up --no-provision
vagrant ssh

  # (inside the vm)
  cd /vagrant/scripts/installers

  # 2 - install atheneum
  ./install-atheneum.sh

  exit

vagrant ssh # again (to reload environment stuff)

  # (inside the vm)
  cd /vagrant/scripts/installers

  # 3 - install the runners you want:
  ./install-runner.rb --install gobstones
  ./install-runner.rb --install haskell

  exit

# 4 - package the VM:
vagrant package --output mumuki.box
mv mumuki.box dist/
```

If anything goes wrong during the download, just `vagrant destroy` the box and start over. We know that's quite annoying, but it's the best we can do for now. :pensive:


### Debian:

```bash
cd dist
./install-and-run.sh
```

### Windows:
```bash
Double click @ MumukiLoader.exe
```
