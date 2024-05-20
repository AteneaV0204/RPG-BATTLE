#!/bin/sh
echo -ne '\033c\033]0;Farming RPG\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/Farming RPG.x86_64" "$@"
