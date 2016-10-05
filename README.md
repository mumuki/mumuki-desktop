# mumuki-offline


**Requires:** Vagrant (1.8+) & VirtualBox


## Creating the VM (online):

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

# 4 - package the VM:
vagrant package --output mumuki.box
mv mumuki.box dist/
```

## Installing the VM (offline):

### Debian:

```bash
cd dist
./install-and-run.sh
```

### Windows:
```bash
Double click @ MumukiLoader.exe
```
