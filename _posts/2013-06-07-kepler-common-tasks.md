---
name: Kepler common tasks
layout: post
title: Kepler common tasks
date: 2013-06-07
categories:
- Kepler common tasks
---
## Kepler common tasks
This tutorial documents some of the tasks that frequently occur when using Kepler. It is not a sequential series of steps, but a collection of independent operations.

## Start Kepler
Kepler can be started using the start menu. You can open the application or open it via the command line. Using the command line can sometimes display extra information useful in debugging workflows and is the way we recommended starting Kepler. To make it easier there is a shortcut installed with the SWISH tools. 
![Start menu](/images/KeplerCommonTasks0010StartMenu1.png)

The command line window while Kepler is running
![Command line window](/images/KeplerCommonTasks0030ConsoleWindow.png)

## Main window
Search and components panel on the left, canvas on the right, play buttons and menus at the top.
![Main window](/images/KeplerCommonTasks0040MainKeplerWindow.png)

## Search for actor or director
Searching is the easiest way to quickly find the part you are looking for. Type in the name and press enter.
![Search](/images/KeplerCommonTasks0045SearchForActor.png)

## Add actor to workflow
Drag and drop using the cursor
![Add actor](/images/KeplerCommonTasks0050DragActor.png)

## Link actors together
Links pass values around the workflow and sequence execution. To link actors use the cursor, click on a port arrow on one actor and drag to the port arrow on another actor.
![Link actor](/images/KeplerCommonTasks0060LinkActorA.png)
![Link actor](/images/KeplerCommonTasks0070LinkActorB.png)
![Link actor](/images/KeplerCommonTasks0080LinkActorC.png)

## Save
Save using the file menu
![Save](/images/KeplerCommonTasks0090SaveWorkflow.png)

## Rename workflow
You will be prompted when saving to give a name, but can also change it afterwards.
![Rename workflow](/images/KeplerCommonTasks0100RenameWorkflowA.png)
![Rename workflow](/images/KeplerCommonTasks0110RenameWorkflowB.png)

## Change actor or director values
Double click on the actor and the values that can be changed appear. To keep changes click the commit button. Eg the constant value actor
![Edit values](/images/KeplerCommonTasks0120EditActorValuesA.png)
![Edit values](/images/KeplerCommonTasks0130EditActorValuesB.png)

## Animate at runtime
Turning this on will display what actor the workflow is up to when running. This given an indication of where a running workflow is up to.
![Animate runtime](/images/KeplerCommonTasks0140RunTimeHighlightA.png)
![ Animate runtime](/images/KeplerCommonTasks0150RunTimeHighlightB.png)

## Execute a workflow
Like a VCR press the play button.
![Play](/images/KeplerCommonTasks0160Play.png)

## Display value
Use the Display actor to view values on screen. The actor can be connected to any other actor. It is useful for debugging and inspecting the results through the workflow.
![Display](/images/KeplerCommonTasks0170DisplayValuesA.png)
![Display](/images/KeplerCommonTasks0180DisplayValuesB.png)

## Move the canvas view
Use the mouse to move the part of the canvas displayed
![Display](/images/KeplerCommonTasks0190NavigateWorkflow.png)

## Actors not linked error
Usually, all actors need to be connected in a complete sequence. This includes actors in sub-modules which can be misleading and tricky to find.
![Link error](/images/ KeplerCommonTasks0210MissingLinkErrorB.png)
![Link error](/images/KeplerCommonTasks0200MissingLinkErrorA.png)

## Rename actor
Actors can be given titles. This can help document the workflow or set the name of an actor to export.
![Rename actor](/images/KeplerCommonTasks0220RenameActora.png)
![Rename actor](/images/KeplerCommonTasks0230RenameActorb.png)
![Rename actor](/images/KeplerCommonTasks0240Renameactorc.png)

## Director missing 
This happens to everyone!
![Director error](/images/ KeplerCommonTasks0250MissingDirectorError.png)

## Export actor
Actors can be saved and then reused in other workflows.
![Export actor](/images/KeplerCommonTasks0260ExportActorA.png)
![Export actor](/images/KeplerCommonTasks0270ExportActorB.png)
![Export actor](/images/KeplerCommonTasks0280ExportActorC.png)
