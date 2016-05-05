# mumuki-offline


**Requires:** Vagrant & VirtualBox


## Creating the VM (requires Internet):

1) Change the `config` file with your needs.

2) Download the base box:
```bash
./base-box-download.sh
```

3) With the `virtualbox.box` file created, run `vagrant up` to create a VM with all the dependencies installed. Now with these files:

```bash
/.vagrant
virtualbox.box
./base-box-install.sh
```

you can run the VM in any place.

# Installing the VM:
```bash
./base-box-install.sh
vagrant up
```

# Start & Stop, Suspend & Resume the VM:
```bash
vagrant up
vagrant halt
vagrant suspend
vagrant resume
```

# View the status
```bash
vagrant status
```