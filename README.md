# Polarion plug

The Polarion plug provides an interface to perform actions in a remote Polarion server
for the Plastic SCM DevOps system.

This is the source code used by the actual built-in Polarion plug. Use it as a reference
to build your own Issue Tracker plug!

# Build
The executable is built from .NET Framework code using the provided `src/Polarionplug.sln`
solution file. You can use Visual Studio or MSBuild to compile it.

**Note:** We'll use `${DEVOPS_DIR}` as alias for `%PROGRAMFILES%\PlasticSCM5\server\devops`
in *Windows* or `/var/lib/plasticscm/devops` in *macOS* or *Linux*.

# Setup
If you just want to use the built-in Polarion plug you don't need to do any of this.
The Polarion plug is available as a built-in plug in the DevOps section of the WebAdmin.
Open it up and configure your own!

## Configuration files
You'll notice some configuration files under `/src/configuration`. Here's what they do:
* `polarionplug.log.conf`: log4net configuration. The output log file is specified here. This file should be in the binaries output directory.
* `issuetracker-polarion.definition.conf`: plug definition file. You'll need to place this file in the Plastic SCM DevOps directory to allow the system to discover your Polarion plug.
* `polarionplug.config.template`: mergebot configuration template. It describes the expected format of the Polarion plug configuration. We recommend to keep it in the binaries output directory
* `polarionplug.conf`: an example of a valid Polarion plug configuration. It's built according to the `polarionplug.config.template` specification.

## Add to Plastic SCM Server DevOps
To allow Plastic SCM Server DevOps to discover your custom Polarion plug, just drop 
the `issuetracker-polarion.definition.conf` file in `${DEVOPS_DIR}/config/plugs/available`.
Make sure the `command` and `template` keys contain the appropriate values for
your deployment!

# Behavior
The **Polarion plug** provides an API for **mergebots** to connect to Polarion. They use
the plug to retrieve issue information from the Issue Tracker server and modify
issue statuses according to the build results.

## What the configuration looks like
When a mergebot requires a Issue Tracker plug to work, you can select a Polarion Plug Configuration.

<p align="center">
  <img alt="Issue Tracker plug select" src="https://raw.githubusercontent.com/PlasticSCM/polarionplug/master/doc/img/issuetracker-plug-select.png" />
</p>

You can either select an existing configuration or create a new one.

When you create a new Polarion Plug Configuration, you have to fill in the following values:

<p align="center">
  <img alt="Polarionplug configuration example"
       src="https://raw.githubusercontent.com/PlasticSCM/polarionplug/master/doc/img/configuration-example.png" />
</p>

## Polarion Configuration

No further configuration is required in the Polarion server.

## How it works
A configured **Polarion plug** receives messages whenever the mergebot needs to find
out whether a task has been properly marked as completed in the issue tracker. It
serves merely as a communication proxy between Polarion and a mergebot.

It's also capable of altering the status of an issue according to its assigned
workflow. The mergebot will tell the **Polarion plug** which transition needs to apply
to a given issue and the **Polarion plug** will communicate with Polarion to make sure
it's done.

# Support
If you have any questions about this plug don't hesitate to contact us by
[email](support@codicesoftware.com) or in our [forum](http://www.plasticscm.net)!
