# Project Title

Name: Roboth dog thing that waters plants

Student Number: C19307843

Video:
[![YouTube](https://www.youtube.com/watch?v=0aEFllZMBcQ)]

apologies as this is the best the Pico screen record functionality can do...

## Description of Project
The idea for my assignment is that I would have a robot dog with an arm
attached to it that it can use to water plants.

The player can send commands to the dog with the vr controller to guide it to the plants
so the dog will feature some pathfinding

The plants will wither over time if not watered in time so this introduces a
semblence of a game feedback loop. The idea is to keep the plants alive.

The setting is taking place in a fallout setting with our robot dog friend
having nothing to do but water plants after everyone has left.

### Extra ideas I thought of after the above initial proposal

potential ideas:
- You or the dog would have a flamethrower to kill plants that would randomly
mutate and become evil plants.
- There could be zombies/ghouls that try to destroy plants and you could have a system
where you water the plants to keep them alive and protect them to gain score

## How it works

### Robot Dog

The robod dog was made and rigged with bones in blender. These bones are used to
implement Inverse Kinematics to give the robot a sense of autonomous movement.

#### The arm

The arm of the robot dog is the most important part. for this it is a long cylinder
with 4 bones for IK movement. The IK implementation I used had a weight feature to
snag the IK to a target on the world, I wanted it to look like a reaching arm but
in this state it just snaps to whatever position and only bends to look at what
you are pointing when its target is within its length.

The arm has a particle system attached to its nozzle that activates then the right
trigger is pressed. I tried to make this look like water.

When you are watering plants, the nozzle has an object attached to it that is used
to raycast.

#### The legs

For the legs I also tried to use IK but i ended up disabling the script at one point
because I could not get it to work and look the way I wanted

```
    -O-----------O-    =>   -O--------O-
    /           /           /          \
   |           |           |            |
   *            ->*        *            *
   ^              ^updated point        ^ moved to new point
raycast points
```

The idea sort of illustrated above was that I cast a ray down from the base of the leg at
an interval or distance since last target, the leg would move to that updated point to give
the illusion of locomotion through the legs where in reality the body is just floating through
the world

### Plant

Plants have a maximum water level before theyre fully watered. I used a slider to show how
much the plants have been watered but due to an issue with references in prefabs I could
not solve, only plants I place manually have a working water level meter on top of them.

The plants are on a plants layer to help distinguish them to the arm raycaster

### Game Master

The game master object controls the game loop, randomly spawns plants in a radius, taking into
consideration the range between existing plants and the robot dog, this is done in a coroutine.
The game master also checks plant watered levels and deletes them if they are maxed and adds 1
to the score.

## List of classes/assets in the project

| Class | Source |
| - | - |
| DogLegMove.cs | Self written |
| DogMoveToTargetPosition.cs | Self written |
| FabricIK.cs | [ref1](https://www.youtube.com/watch?v=qqOAzn05fvk), [ref2](https://github.com/ditzel/SimpleIK) |
| inverse_kinematics.cs | used multiple tutorials and guides, doesnt work as intended, big reference from above |
| FollowCamera.cs | Self written |
| GameMaster.cs | Self written |
| LegIKHelper.cs | Self written |
| LookAwayFromParent.cs | Self written |
| PlantBehaviour.cs | Self written|
| RightControllerActions.cs | Self written |
| TransformCopier.cs | Self written |

| Asset | Source |
| dog/robot_dog and its iterations | self made in blender |
| pot | self made |
| plant | combination of self made pot and tree + rock assets from [ref](https://assetstore.unity.com/packages/3d/vegetation/trees/japanese-garden-pack-179492) |
| concrete floor material | [ref](https://assetstore.unity.com/packages/2d/textures-materials/concrete/clean-concrete-texture-37028) |
| material packs by Yughues | [ref1](https://assetstore.unity.com/packages/2d/textures-materials/metals/yughues-free-metal-materials-12949), [ref2](https://assetstore.unity.com/packages/2d/textures-materials/metals/yughues-free-pbr-metal-plates-35362), [ref3](https://assetstore.unity.com/packages/2d/textures-materials/concrete/yughues-free-concrete-materials-12951) |

## What I am most proud of in the assignment

even though I didnt get it working 100% as I wanted I thought the math behind Inverse kinematics
was pretty cool.

The project in general was nice as you are playing around the (meta?)physical VR representation
of words and numbers you have written into an electric rock processor which is kinda wild to think
about. You dont get this kind of response from your work in other modules.

I dont feel like i've nowhere near *finished* this but I do think it does what i said it would do on the
proposal which is a robot dog taht waters plants...

After giving VR a fair shot im pretty excited to develop for it, I want to make a game involving
grappling gun movement.