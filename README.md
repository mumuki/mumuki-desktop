# mumuki-offline


**Requires:** Vagrant & VirtualBox


## Creating the VM (online):

```bash
# 1 - create the VM and all its dependencies:
vagrant up

# 2 - install the runners you want:
./install-runner.sh mumuki/mumuki-hspec-server

# 3 - package the VM:
vagrant package --output mumuki.box
cp mumuki.box dist/
```

## Installing the VM (offline):
```bash
cd dist/
./mumuki-box-install.sh
vagrant up
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
