# Unity Build System

## Goal

Provide an Editor Extension which allows adding multiple build targets and batch building all, one or a subset of these targets. 

Each target corresponds to a unity deploy plattform and should allow adding custom scripts to the build process to pre- and post-process the build. 

## Thanks

Thank you to all contributors: @malud @olaf.spiewok @fixed @ingo-hessling @flberger-work

## Getting started

Welcome to the documentation for the Unity Build System. 

### Fast forward

Don't want to read the immense documentation?

Some quick links: 

1. Implement \ref UBS.IBuildStepProvider to add custom build steps
1. Set Version information at runtime or in the editor using \ref UBS.BuildVersion
1. Build from command line using \ref UBS.UBSProcess::BuildFromCommandLine() 

### Why use it?

If you have to deploy your game to multiple stores or to multiple platform variations (Ouya, Phone, Tablet) Unity quickly runs out of options. To ease and automate the configuration needed for each platform, this build system was created. 

There are several great features, which I will explain. 

#### Custom scene selection

For each of your builds you can customize which scenes are part of your build and which are not. This is great if you want to build a free version with fewer levels or if you don't need a specific loader scene in one build. 

Also you can set an Output path for all your builds. So you no longer overwrite your most recent build with the new one by accident. 

#### Custom build steps (pre and post)

Once a build is triggered and the build setup is complete you get to run custom code before unity even builds. This is very handy to setup compiler flags or reimport assets with different settings, regenerate atlases and so on. Once your build is finished you can run even more code. For example to unset compiler flags. 

If during your steps a recompile occurs, the system will handle that as well. There is even a step, that waits for a compile to finish. 

The system provides you with an interface. Any custom class can implement it and become a build step. Look here. \ref UBS.IBuildStepProvider


#### Automatically Build multiple targets

With the hit of a button you can build multiple targets. For example: You have a game for several android stores. Simply select all your build targets and hit build. The system will build each of them one after the other. 

If you use an automated build solution such as jenkins, you can call the build system via the command line as well. 


#### Integrated version handling

The build system has an integrated Version class. You can update it in the build collection editor, in one of your custom build steps and you can read it at runtime. See \ref UBS.BuildVersion

#### Getting started


1. get the latest version
2. import the build system into your project
3. create your build collection
4. create a build process
5. build


#### Get the latest version


To get started, you should get the latest version of this software here https://github.com/kwnetzwelt/unity-build-system This is a git repository. You can either clone it onto your workstation or you download a zip file from bitbucket.org. 

#### Create your build collection


A build collection hold all your build processes. That is, it is a collection of actual _build_ you want to target. For example a build collection could contain: Google Play PVR Debug, Google Play ATC Final and so on. You can have multiple build collections to logically group your build targets. For example one collection could contain all android builds another contains all windows builds. 

To create a build collection you simply right click in your project window in Unity. You can then choose `Create->UBS Build Collection`. 

It will create an asset in your project. And you get a custom inspector view like this. 

#### Create a build process


A build process is your actual build target. You create one in the Editor Window of your build collection. Simply hit the big `+` button to add a process. Now you need to setup your process. 

1. give it a name
2. select a target platform
3. choose the output path
4. select scenes which should be included

Observe that, depending on the target platform, the output path must either point to the executable file you want to build, or a folder you want to deploy to. The path must be relative to the project directory, absolute paths are not supported.

#### Build


To build your build process (or multiple processes), switch back to the inspector and select all processes you want. You can now hit `Build`. 

The system will now start to run your builds and inform you on its status in a small window which looks like this. 
