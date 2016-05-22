#!/bin/bash

. try.sh

function installIfNeeded {
  local name=$1
  local install=$2
  
  which "$name"
  if [[ $? -ne 0 ]]; then
    echo "Install $name: INSTALLING"
    "$2"
  else
    echo "Install $name: NOTNEEDED"
  fi
}

function installVirtualBox {
  try sudo dpkg -i install-virtualbox.deb
  try sudo /etc/init.d/vboxdrv setup
}

function installVagrant {
  try sudo dpkg -i install-vagrant.deb
}

# Install software
installIfNeeded "virtualbox" installVirtualBox
installIfNeeded "vagrant" installVagrant

# Install the box
boxes=`vagrant box list`
if [[ $boxes =~ "mumuki" ]]; then
  echo "The mumuki box is installed!"
else
  echo "Installing mumuki.box..."
  ./mumuki-box-install.sh
fi

try vagrant up --no-provision
try vagrant provision
try firefox --url="http://localhost:3000"
