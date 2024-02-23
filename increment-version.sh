#!/bin/bash

script_dir="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
versionFilePath="${script_dir}/version.txt"
cd "$script_dir" || exit

# Read the version from version.txt
versionText=$(cat "$versionFilePath")

# Use grep with regular expressions to match and capture version number components
if [[ $versionText =~ ^[[:space:]]*([0-9]+)\.([0-9]+)\.([0-9]+)\.([0-9]+)[[:space:]]*$ ]]; then
    major=${BASH_REMATCH[1]}
    minor=${BASH_REMATCH[2]}
    build=${BASH_REMATCH[3]}
    revision=${BASH_REMATCH[4]}

    # Increment the revision number
    newRevision=$((revision + 1))
    newVersion="$major.$minor.$build.$newRevision"

    # Save the updated version back to version.txt
    echo $newVersion > "$versionFilePath"

    # Output the new version
    echo $newVersion
else
    echo "Version format not recognized."
fi
