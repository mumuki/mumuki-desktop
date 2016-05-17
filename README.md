# mumuki-offline


**Requires:** Vagrant & VirtualBox


## Creating the VM (online):

```bash
# 1 - create the VM:
vagrant up --no-provision
vagrant ssh

  # (inside the vm)
  cd /vagrant/scripts/installers

  # 2 - install atheneum
  ./install-atheneum.sh

  # 3 - install the runners you want:
  ./install-runner.rb --install gobstones
  ./install-runner.rb --install haskell

# 4 - package the VM:
vagrant package --output mumuki.box
mv mumuki.box dist/
```

## Installing the VM (offline @ linux):
```bash
cd dist
./install-and-run.sh
```

### Vagrant commands
#### Start & Stop, Suspend & Resume the VM:
```bash
vagrant up
vagrant halt
vagrant suspend
vagrant resume
```

#### View the status
```bash
vagrant status
```
