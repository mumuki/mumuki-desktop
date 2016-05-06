# mumuki-offline


**Requires:** Vagrant & VirtualBox


## Creating the VM (online):

```bash
# 1 - create the VM and all its dependencies:
vagrant up
vagrant ssh -c "cd /vagrant ; ./install-atheneum.sh"

# 2 - install the runners you want:
# //TODO

# 3 - package the VM:
vagrant package --output mumuki.box
mv mumuki.box dist/
```

## Installing the VM (offline):
```bash
cd dist/
./mumuki-box-install.sh
./run.sh
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
