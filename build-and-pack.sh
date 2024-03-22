#!/bin/bash

script_dir="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
version=$(cat "${script_dir}/version.txt")
cd "$script_dir" || exit
pwd

csproj_file=$(find . -name "*.csproj" -print -quit)

# Check if a .csproj file was found
if [ -z "$csproj_file" ]; then
    echo "No .csproj file found."
    exit 1
fi

# Use xmllint to extract the PackageId value
package_id=$(grep -m 1 "<PackageId>" "$csproj_file" | awk -F'[<>]' '{print $3}')

echo "PackageId: $package_id"

if [ -z "$TF_BUILD" ]; then
  dotnet restore 
  dotnet build -c Debug
  dotnet pack -c Debug -p:Version="$version" -o ~/nuget
else 
  dotnet restore
  dotnet build -c Release
  dotnet pack -c Release -p:Version="$version" -o $BUILD_ARTIFACTSTAGINGDIRECTORY 
fi      
    
