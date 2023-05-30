# DNN Connect 2023 Demo Module

This module project was used in two presentations at DNN Connect 2023 (25 - 28 May 2023) to (1) demonstrate hooking in a React application into
DNN and (2) how to build a security layer in the module and leverage this in the front end.

## What does it do?

The module maintains a list of events for a cultural agenda. The three core objects are:

1. Items: events that have a start and end date
2. Categories: each item belongs to a category
3. Venues: each item takes place in one venue

## Building

Run ```.\build.ps1``` to build the module. It uses Cakebuild and Dnn.CakeUtils to build and package.

## Developing

Add ```local.json``` to the root folder with the following blurb:

``` json
{
  "dnn": {
    "pathsAndFiles": {
      "devSiteUrl": "http://mydevsiteurl",
      "devSitePath": "C:\\Modules\\DNNC2023C"
    }
  }
}
```

Where C:\\Modules\\DotNetNuke is the path to the root of your DNN installation you're using to test the module.

Run ```npm run watch``` to build and watch the React code. Run ```npm run watch-server``` to copy files over to the development DNN installation using the path above.


