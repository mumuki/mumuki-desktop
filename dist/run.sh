#!/bin/bash

vagrant up
vagrant ssh -c "cd mumuki-atheneum ; ./start_offline.sh"
