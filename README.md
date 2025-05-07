# 2D-Interactive-Map
 A template for a Mario-3-style map, made with Unity and C#

# Introduction
I was asked to make a map that emulated some of the functionality from the map from Mario 3. The player will be able to move to different locations, and load into a level. The end-goal was to make it easy for a designer to come in, change the graphics associated for each component and add the name or index of the scenes to load, and have a fully functional map screen up and running in a few minutes. 

For the purpose of this project, the demo level is a blank scene.

# Game Objects
We will start with custom game objects

## Custom Game Objects
### Game Master (GM)
Location: Assets/GM
The Game Master game object controls the flow of the game.
### Player
Location: Assets/Player
The Player game object represents the player's location and holds player state
### Spaces
Spaces are spots the player can move to and land on. There are 2 different types that have different functionality, but they inherit from the same script.
#### Level
Location: Assets/Spaces/Level
A level space contains data for transitioning to a new level.
#### Go
Location: Assets/Spaces/Go
A go space automatically moves the player to the next space.

## Modified Unity Game Objects
### Line (Line Renderer)
Location: Assets/Spaces
A line connects two separate spaces together. Line game objects are the result of combining Unity's Line Renderer component and a 'Line Controller' script.

# Usage
If starting fresh, drag and drop your space game objects into the scene. **It is recommended you drop them into the heirarchy, instead of directly into the scene, so as to have them all stack at 0.0-x,0.0-y. 0.0-z.**

Move the game objects to their desired destinations. **It is recommended you move the game objects using their Transform component directly, so as to make sure lines are straight horizontal or vertical, instead of diagonal.**

Count how many connections you need, and bring that many Line prefabs into the scene. In the 'Space1' and 'Space2' boxes, assign the corresponding spaces the line will connect.

Drag in 1 Player and 1 GM game object. In the GM game object, assign the starting space. In each 'Level Space' game object, assign the corresponding level's index ID, located in the build settings (File -> Build Settings). Any level listed as 0 will not load a level, as the script assumes the map is on level 0 and it shouldn't load itself.

Assign the level indexes for level spaces, and the next and previous spaces for go spaces. Also for go, assign direction for each option.

# Developer Notes
