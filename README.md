# Masterplan

Masterplan is an application that helps you to build D&D 4E campaigns.

You can outline your plot structure, build encounters and maps, detail your campaign world, and create custom creatures and NPCs.

## Installing it

To install Masterplan, get the `Masterplan.zip` file from the latest release, which can be found here:

https://github.com/andyaiken/masterplan/releases/latest

Extract all the files in this zip into their own folder, and run `Masterplan.exe`.

## Building and running it

**Prerequisites** You'll need to have Visual Studio installed (community edition is fine), and the `Microsoft Visual Studio Installer Projects` extension loaded.

To build Masterplan, open `Masterplan.sln` in Visual Studio and build the `Masterplan` project (F6).

Bear in mind that every time you build Masterplan in Visual Studio, the library files are copied from `./Libraries` into the output folder, so any changes you make to these libraries won't be retained.

The other project in the solution is called `Setup`, which creates an installer.

## Contributing to it

If you find a bug, or you think of a feature that should be in Masterplan, please add something to the GitHub Issues tab (https://github.com/andyaiken/masterplan/issues).

If you're a coder, feel free to submit pull requests to the main repo.
