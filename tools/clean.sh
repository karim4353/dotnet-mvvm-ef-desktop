#!/usr/bin/env bash
set -e
echo 'Cleaning builds and DB...'
rm -rf src/**/bin src/**/obj data/ensit.db logs/*.log
echo 'Done'
