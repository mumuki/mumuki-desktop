#!/bin/bash

FILE="mumuki.box"

if [ ! -f "./$FILE" ]; then
  echo "I require a '$FILE' file but it's not here. Aborting..."
  exit 1
fi

vagrant box add mumuki "./$FILE"
