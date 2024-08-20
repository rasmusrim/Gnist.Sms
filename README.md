# Gnist.Sms

## Introduction
A library to send SMS via the Telenor Gateway described
here: https://gnist.sykehuspartner.no/apis/c4220ae1-a0e4-431d-bb9f-8f67f376b9bd

The library was first written by The hospital in Vestfold (SiV) by Rasmus Rimestad (rasmus.rimestad@cloudberries.no)

## How to use
See [examples/SmsSender.cs](examples%2FSmsSender.cs)

I have no idea what most of the config values mean, and I am able to send SMS with almost any value in most of them. So
The only really required config value, is Wsdl. The other values are probably used for logging and billing purposes, so
you should probably try to find correct and meaningful values for them.

## Developing
The version of this library is found in the file `version.txt`. If you run the script `increment-version.sh` it will
increase the revision version by one. After that, you can run `build-and-pack.sh` to build and pack the library. If you
ruin this script from your local machine, the nuget package will be put into the `~/nuget` folder, and you can include
it into your other project from there.

## Nuget
This library is not yet in any public Nuget library.



 