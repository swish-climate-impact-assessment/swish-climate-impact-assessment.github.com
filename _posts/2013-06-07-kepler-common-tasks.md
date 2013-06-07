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
<br>![Start menu](/images/KeplerCommonTasks0010StartMenu1.png)<br>

The command line window while Kepler is running
<br>![Command line window](/images/KeplerCommonTasks0030ConsoleWindow.png)<br>

## Main window
Search and components panel on the left, canvas on the right, play buttons and menus at the top.
<br>![Main window](/images/KeplerCommonTasks0040MainKeplerWindow.png)<br>

## Search for actor or director
Searching is the easiest way to quickly find the part you are looking for. Type in the name and press enter.
<br>![Search](/images/KeplerCommonTasks0045SearchForActor.png)<br>

## Add actor to workflow
Drag and drop using the cursor
<br>![Add actor](/images/KeplerCommonTasks0050DragActor.png)<br>

## Link actors together
Links pass values around the workflow and sequence execution. To link actors use the cursor, click on a port arrow on one actor and drag to the port arrow on another actor.
<br>![Link actor](/images/KeplerCommonTasks0060LinkActorA.png)<br>
<br>![Link actor](/images/KeplerCommonTasks0070LinkActorB.png)<br>
<br>![Link actor](/images/KeplerCommonTasks0080LinkActorC.png)<br>

## Save
Save using the file menu
<br>![Save](/images/KeplerCommonTasks0090SaveWorkflow.png)<br>

## Rename workflow
You will be prompted when saving to give a name, but can also change it afterwards.
<br>![Rename workflow](/images/KeplerCommonTasks0100RenameWorkflowA.png)<br>
<br>![Rename workflow](/images/KeplerCommonTasks0110RenameWorkflowB.png)<br>

## Change actor or director values
Double click on the actor and the values that can be changed appear. To keep changes click the commit button. Eg the constant value actor
<br>![Edit values](/images/KeplerCommonTasks0120EditActorValuesA.png)<br>
<br>![Edit values](/images/KeplerCommonTasks0130EditActorValuesB.png)<br>

## Animate at runtime
Turning this on will display what actor the workflow is up to when running. This given an indication of where a running workflow is up to.
<br>![Animate runtime](/images/KeplerCommonTasks0140RunTimeHighlightA.png)<br>
<br>![ Animate runtime](/images/KeplerCommonTasks0150RunTimeHighlightB.png)<br>

## Execute a workflow
Like a VCR press the play button.
<br>![Play](/images/KeplerCommonTasks0160Play.png)<br>

## Display value
Use the Display actor to view values on screen. The actor can be connected to any other actor. It is useful for debugging and inspecting the results through the workflow.
<br>![Display](/images/KeplerCommonTasks0170DisplayValuesA.png)<br>
<br>![Display](/images/KeplerCommonTasks0180DisplayValuesB.png)<br>

## Move the canvas view
Use the mouse to move the part of the canvas displayed
<br>![Display](/images/KeplerCommonTasks0190NavigateWorkflow.png)<br>

## Actors not linked error
Usually, all actors need to be connected in a complete sequence. This includes actors in sub-modules which can be misleading and tricky to find.
<br>![Link error](/images/ KeplerCommonTasks0210MissingLinkErrorB.png)<br>
<br>![Link error](/images/KeplerCommonTasks0200MissingLinkErrorA.png)<br>

## Rename actor
Actors can be given titles. This can help document the workflow or set the name of an actor to export.
<br>![Rename actor](/images/KeplerCommonTasks0220RenameActora.png)<br>
<br>![Rename actor](/images/KeplerCommonTasks0230RenameActorb.png)<br>
<br>![Rename actor](/images/KeplerCommonTasks0240Renameactorc.png)<br>

## Director missing 
This happens to everyone!
<br>![Director error](/images/ KeplerCommonTasks0250MissingDirectorError.png)<br>

## Export actor
Actors can be saved and then reused in other workflows.
<br>![Export actor](/images/KeplerCommonTasks0260ExportActorA.png)<br>
<br>![Export actor](/images/KeplerCommonTasks0270ExportActorB.png)<br>
<br>![Export actor](/images/KeplerCommonTasks0280ExportActorC.png)<br>
