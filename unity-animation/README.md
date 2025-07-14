
Curriculum
[C#24] Spe - AR/VR 2025

Unity - Animation
 Master
 By: Carrie Ybay, Software Engineer at Holberton School
 Weight: 1
 Your score will be updated as you progress.
 Manual QA review must be done (request it when you are done with the project)
Description
Quiz
Background Context
Welcome to a project that will test your codebase and state machines to support real-time animations and animation blending. This project will not only enhance your understanding of how code architecture influences animation and other aspects of game development but also provide you with a deep dive into how 3D animation is created and modified inside of the Unity Editor.

Animation is the heart of character control and environmental interaction in games. It breathes life into your characters, making them move, react, and interact. It’s the illusion of life that brings your game world into existence. This project will guide you through the process of creating and controlling animations in Unity, from simple movements to complex sequences.

Upon completion of this project, you will have a solid understanding of Unity’s animation system, and you will be able to create and control a variety of animations for your game characters and environment.

Are you ready to bring your game to life?

Technical Description
This project focuses on the following key areas:

Understanding Animation: Learn the difference between 2D and 3D animation, and understand the parts of a 3D model and how they are animated.
Unity Animation System: Get to know Unity’s animation system, including Animation Clips and Animator Controllers.
Animation Implementation: Learn how to import and use Animation Clips, and how to control them with scripts.
State Machines: Understand the concept of a State Machine and a Sub-State Machine, and how they are used in animation control.
Root Motion: Learn about Root Motion and how it can be used to create more realistic movement in your animations.
Please create a separate Unity project under the holbertonschool-unity repo, naming it unity-animation.

You are expected to iterate upon your codebase from the previous UI project. If you do not have a workable version, you can use this Starter Codebase as the base for this project.

Note: Using free or paid script assets from the Unity Asset Store or elsewhere is prohibited for this project. Focus on creating your own scripts that interact with Unity’s character controller components.

The final product after the next few projects will function like this: Platformer - Final

At the end of this Animation project, we will be at this stage in development: Platformer WIP - Animation

Resources
Core:

What is the difference between 2D and 3D animation? (We will not be covering how to create models, rigs, or animations in 3D modeling software, but it’s important to understand the parts of a 3D model and how they are animated.)
Unity Manual: Animation (Read sections “Animation System Overview”, “Animation Clips”, “Animator Controllers”)
The Animation View
Animation 101 - Intro to Animation in Unity
Mecanim and Mixamo in Unity
Suggested:

Animation Properties
Animation Curves
Animation Events
The Animator Component
The Animator Controller
Animator Scripting
Complimentary:

Unity Manual
Unity Manual: Animation Reference
Unity Manual: Glossary of Animation Terms
Learning Objectives
At the end of this project, you are expected to be able to explain to anyone, without the help of Google:

General
What is a keyframe?
How is 2D Animation different from 3D animation?
What are Dopesheets and how do you use them?
What are Curves and how do you use them?
How to import and use Animation Clips?
What are Animator Controllers and how do you use them?
What is a State Machine?
What is a Sub-State Machine?
What is Root Motion?
How does animation enhance the player’s gaming experience?
How to create and control a variety of animations in Unity?
Requirements
General
A README.md file, at the root of the folder of the project
Use Unity’s default .gitignore in your holbertonschool-unity directory
Push the entire project folder unity-animation to your repo
All scenes and project assets (such as Scenes, Scripts, Materials, etc.) must be organized as stated in the tasks
Your scripts should include markup and notation to describe functionality, bugs, and help make the codebase easier to read and understand
Free or paid assets are not permitted for this project. Focus on creating your own scripts that interact with Unity’s existing character controller components.
Tasks
0. Cinematic universe
mandatory
We’re continuing to add on to the Platformer project to add animation (see example). Duplicate your 0x06-unity-assets_ui directory from the previous project and rename it unity-animation.

In Level01 scene, disable Main Camera by clicking on the checkbox next to its name in the Inspector. Create a new Camera GameObject named CutsceneCamera. The camera should be facing the end flag.



Open the Animation tab (CTRL + 6), and with CutsceneCamera selected, click on the Create button inside the Animation tab. Save the new Animation with the name Intro01. Create two new folders Animations and Animators. Put Intro01 into the Animations folder and CutsceneCamera into the Animators folder.

Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level01.unity, Assets/Animations/Intro01.anim, Assets/Animators/CutsceneCamera.controller
 
0/2 pts
1. Keyframes
mandatory
With Intro01 open in the Animation tab, use keyframes to animate the CutsceneCamera‘s Position and Rotation so that the camera pulls back from the flag, panning over the length of the platforms, and stopping behind the player, ending in the position and rotation of the Main Camera.



CutsceneCamera End Position: x: 0, y: 2.5, z: -6.25
CutsceneCamera End Rotation: x: 9, y: 0, z: 0
The camera’s position and rotation can be of any value during the animation as well as start with a close up shot of the flag and stop at the given values in this task so that the transition of the view from CutsceneCamera to Main Camera in the next task will be seamless. The animation should not loop.

Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level01.unity, Assets/Animations/Intro01.anim, Assets/Animators/CutsceneCamera.controller
0/5 pts
2. Transitions
mandatory
Open the CutsceneCamera Animator in the Animator tab. Make sure that Entry has a transition to Intro.

Disable PlayerController script in the Player GameObject and disable the TimerCanvas. Create a script called CutsceneController.cs and attach it to the CutsceneCamera GameObject. This script should do the following when the Level01 animation is finished playing:

Enable Main Camera
Enable PlayerController
Enable TimerCanvas
Disable CutsceneController
When you press Play on the Level01 scene, the Intro01 animation should play. The Player should not be able to move during the animation. When the camera stops behind the Player, the Timer should become visible but not start. When the Player moves, the Timer should start and the Main Camera should follow the Player. From this point, gameplay should continue as developed in the previous projects.



Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level01.unity, Assets/Scripts/CutsceneController.cs, Assets/Animators/CutsceneCamera.controller
0/9 pts
3. Sorry Sylvain, it's not a Tic Tac anymore
mandatory
Download this character model and import it into your Models folder. You may need to remap the materials and textures associated with the model. If you cannot find the materials and/or textures, extract them from the model’s Materials tab in the Inspector.

In the Hierarchy window, disable Player‘s Mesh Renderer and make the model ty.fbx a child of the Player GameObject. Press Play to test it. The model should be in T-pose and move exactly the same as the Capsule placeholder object did, while in T-pose.

Make sure the ty.fbx model has these properties in the Inspector:

Rig
Animation Type: Humanoid
Avatar Definition: Create From This Model


If you have not already saved Player as a prefab, do so now and put it in the Prefabs folder.

Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level01.unity, Assets/Models/ty.fbx, Assets/Prefabs/Player.prefab
 
0/4 pts
4. Running in circles
mandatory
Edit CameraController.cs so that the camera still follows the player, but when the player turns, it does not change the orientation of the camera. The only rotation the camera should do is when the player moves the camera with the mouse.



Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level01.unity, Assets/Scripts/CameraController.cs
0/9 pts
5. Happily idling
mandatory
All of the animations we’ll be using in this project are from Mixamo.

Download this Animation Clip and import it into your Animations folder. Assign the following settings in the Inspector:

Rig
Animation Type: Humanoid
Avatar Definition: Create From This Model
In the Animators folder, create a new Animator named ty.controller. Drag the Happy Idle animation into the Animator tab and create a transition from the Entry state to the Happy Idle state.

The Happy Idle animation should loop continuously while the player isn’t moving. Attach the Animator to the ty model inside the Player prefab.



Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level01.unity, Assets/Animations/ty@Happy Idle.fbx, Assets/Animators/ty.controller
 
0/4 pts
6. Run boy run
mandatory
Download this Animation Clip and import it into your Animations folder. Change the settings so that they match Happy Idle‘s settings.

Drag the Running animation into the ty Animator and create transitions to and from the Happy Idle state. Name the transitions IdleToRunning and RunningToIdle accordingly.

The Running animation should start immediately (i.e. the Running animation shouldn’t wait until the Happy Idle animation is finished to start). When the player stops running, the Running animation should stop and the Happy Idle animation should start again.



Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level01.unity, Assets/Animations/ty@Running.fbx, Assets/Animators/ty.controller
 
0/8 pts
7. Jump, jump
mandatory
Download this Animation Clip and import it into your Animations folder. Change the settings so it matches Happy Idle and Running‘s settings.

Drag the Jump animation into the ty Animator and create transitions to and from the Happy Idle state as well as the Running state. Name the transitions IdleToJump, JumpToIdle, JumpToRunning, and RunningToJump accordingly.

If the player is standing still, the Jump animation should start immediately (i.e. the Jump animation shouldn’t wait until the Happy Idle animation is finished to start). When the player lands, the Jump animation should stop and the Idle animation should start again. The Jump animation should play only once and not loop.

If the player is running, the Jump animation should start immediately (i.e. the Jump animation shouldn’t wait until the Running animation is finished to start). When the player lands, the Jump animation should stop and if the player is still moving forward, the Running animation should start again. If the player is no longer moving forward, the Idle animation should start again.



Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level01.unity, Assets/Animations/ty@Jump.fbx, Assets/Animators/ty.controller
 
0/8 pts
8. Free falling
mandatory
Create a new Sub-state Machine called FallingDown. Create transitions to it from Running and Jump named RunningToFalling and JumpToFalling.

Download this Animation Clip and import it into your Animations folder.

Add a new State called Falling inside the FallingDown Sub-state Machine. When the player is falling from a platform, whether they run off or jump off, the Falling animation should play until the player lands on the starting position again.



Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level01.unity, Assets/Animations/ty@Falling.fbx, Assets/Animators/ty.controller
 
0/10 pts
9. Splat
mandatory
Download this Animation Clip and import it into your Animations folder.

Add a new State called Falling Flat Impact. Create a transition from Falling to Falling Flat Impact called FallingToImpact. This animation should play when the player lands on the starting position after falling. This animation should play once and not repeat.



Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level01.unity, Assets/Animations/ty@Falling Flat Impact.fbx, Assets/Animators/ty.controller
 
0/10 pts
10. Down but not out
mandatory
Download this Animation Clip and import it into your Animations folder.

Add a new State called Getting Up. Create a transition from Falling Flat Impact to Getting Up named ImpactToGettingUp. Create a transition from the FallingDown sub-state to Idle named GettingUpToIdle. This animation should play after the Falling Flat Impact animation finishes. This animation should play once and not repeat.



Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level01.unity, Assets/Animations/ty@Getting Up.fbx, Assets/Animators/ty.controller
 
0/10 pts
11. Animated features
mandatory
Update the Level02 and Level03 scenes to have their own intro animations named Intro02 and Intro03 respectively. Replace the placeholder player with the animated model in each scene as well.

Some of the animations may not transition well or may clip through the floor or have other visual issues. Change the animations’ settings in the Inspector accordingly to adjust. (Hint) You should also edit the transition times or animation length times to create smooth animations and a good player experience.

Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Scenes/Level02.unity, Assets/Scenes/Level03.unity, Assets/Animators/ty.controller, Assets/Animations/*.fbx, Assets/Animations/Intro02.anim, Assets/Animations/Intro03.anim
0/12 pts
12. Not quite done yet
mandatory
Scenes in Build:

MainMenu
Options
Level01
Level02
Level03
Create three builds of all scenes above in the Builds directory.

Windows and Linux builds should be set to x86_64 architecture
Build Folder Hierarchy:

Builds
Linux
Platformer_Data
Platformer.x86_64
Mac
Platformer.app
Windows
Platformer_Data
Platformer.exe
UnityPlayer.dll
Make sure to run your build and make sure it works! Test your build on all three platforms if possible, but at the very least test on your own computer.

Create a .zip of each build:

Platformer_Mac.zip
Platformer_Linux_x86_64.zip
Platformer_Windows_x86_64.zip
Upload the three .zip files to Google Drive or Dropbox. Add the links to the files below.

Add URLs here:
Repo:

GitHub repository: holbertonschool-unity
Directory: unity-animation
File: Assets/Builds/*
0/8 pts

Tasks list
Mandatory
Advanced
0. Cinematic universe
1. Keyframes
2. Transitions
3. Sorry Sylvain, it's not a Tic Tac anymore
4. Running in circles
5. Happily idling
6. Run boy run
7. Jump, jump
8. Free falling
9. Splat
10. Down but not out
11. Animated features
12. Not quite done yet
Welcome to the chat! Type a message to get started.


