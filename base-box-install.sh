#!/bin/bash

FILE="base-box.box"

if [ ! -f "./$FILE" ]; then
    echo "I require a '$FILE' file but it's not here. Please run './base-box-download.sh' and retry. Aborting..."
    exit 1
fi

vagrant box add ubuntu/trusty64 "./$FILE"