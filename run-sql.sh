#!/bin/bash

COMMAND=/tmp/sql-command-$RANDOM.sql
echo "$@" > $COMMAND
sudo -u postgres psql -a -f $COMMAND
RESULT=$?
rm $COMMAND
exit $RESULT
