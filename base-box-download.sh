#!/bin/bash

FILE="base-box.box"

LINK="https://atlas.hashicorp.com/ubuntu/boxes/trusty64/versions/20160406.0.0/providers/virtualbox.box"
wget --version foo >/dev/null 2>&1 || { echo >&2 "I require 'wget' but it's not installed. Please install it and retry. Aborting..."; exit 1; }
wget -0 "$FILE" $LINK