---
name: Adding custom Stata scripts
layout: post
title: Adding custom Stata scripts
date: 2013-05-30
categories:
- Adding custom Stata scripts
---
## Kepler common tasks
This tutorial documents some of the tasks that frequently occur when using Kepler. It is not a sequential series of steps, but a collection of independent operations.

## Start Kepler
Kepler can be started using the start menu. You can open the application or open it via the command line. Using the command line can sometimes display extra information useful in debugging workflows and is the way we recommended starting Kepler. To make it easier there is a shortcut installed with the SWISH tools. 
![Start menu](/images/KeplerCommonTasks0010StartMenu1.PNG)

The command line window while Kepler is running
![Command line window](/images/KeplerCommonTasks0030ConsoleWindow.PNG)

## Main window
Search and components panel on the left, canvas on the right, play buttons and menus at the top.
![Main window](/images/KeplerCommonTasks0040MainKeplerWindow.PNG)

## Search for actor or director
Searching is the easiest way to quickly find the part you are looking for. Type in the name and press enter.
![Search](/images/KeplerCommonTasks0045SearchForActor.PNG)

## Add actor to workflow
Drag and drop using the cursor
![Add actor](/images/KeplerCommonTasks0050DragActor.PNG)

## Link actors together
Links pass values around the workflow and sequence execution. To link actors use the cursor, click on a port arrow on one actor and drag to the port arrow on another actor.
![Link actor](/images/KeplerCommonTasks0060LinkActorA.PNG)
![Link actor](/images/KeplerCommonTasks0070LinkActorB.PNG)
![Link actor](/images/KeplerCommonTasks0080LinkActorC.PNG)

## Save
Save using the file menu
![Save](/images/KeplerCommonTasks0090SaveWorkflow.PNG)

## Rename workflow
You will be prompted when saving to give a name, but can also change it afterwards.
![Rename workflow](/images/KeplerCommonTasks0100RenameWorkflowA.PNG)
![Rename workflow](/images/KeplerCommonTasks0110RenameWorkflowB.PNG)

## Change actor or director values
Double click on the actor and the values that can be changed appear. To keep changes click the commit button. Eg the constant value actor
![Edit values](/images/KeplerCommonTasks0120EditActorValuesA.PNG)
![Edit values](/images/KeplerCommonTasks0130EditActorValuesB.PNG)

## Animate at runtime
Turning this on will display what actor the workflow is up to when running. This given an indication of where a running workflow is up to.
![Animate runtime](/images/KeplerCommonTasks0140RunTimeHighlightA.PNG)
![ Animate runtime](/images/KeplerCommonTasks0150RunTimeHighlightB.PNG)

## Execute a workflow
Like a VCR press the play button.
![Play](/images/KeplerCommonTasks0160Play.PNG)

## Display value
Use the Display actor to view values on screen. The actor can be connected to any other actor. It is useful for debugging and inspecting the results through the workflow.
![Display](/images/KeplerCommonTasks0170DisplayValuesA.PNG)
![Display](/images/KeplerCommonTasks0180DisplayValuesB.PNG)

## Move the canvas view
Use the mouse to move the part of the canvas displayed
![Display](/images/KeplerCommonTasks0190NavigateWorkflow.PNG)

## Actors not linked error
Usually, all actors need to be connected in a complete sequence. This includes actors in sub-modules which can be misleading and tricky to find.
![Link error](/images/ KeplerCommonTasks0210MissingLinkErrorB.PNG)
![Link error](/images/KeplerCommonTasks0200MissingLinkErrorA.PNG)

## Rename actor
Actors can be given titles. This can help document the workflow or set the name of an actor to export.
![Rename actor](/images/KeplerCommonTasks0220RenameActora.PNG)
![Rename actor](/images/KeplerCommonTasks0230RenameActorb.PNG)
![Rename actor](/images/KeplerCommonTasks0240Renameactorc.PNG)

## Director missing 
This happens to everyone!
![Director error](/images/ KeplerCommonTasks0250MissingDirectorError.PNG)

## Export actor
Actors can be saved and then reused in other workflows.
![Export actor](/images/KeplerCommonTasks0260ExportActorA.PNG)
![Export actor](/images/KeplerCommonTasks0270ExportActorB.PNG)
![Export actor](/images/KeplerCommonTasks0280ExportActorC.PNG)
