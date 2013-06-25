---
name: tutorial-hot-days-with-little-relief-in-Kaleen
layout: default
title: Tutorial: Hot days with little relief in Kaleen
date: 2013-05-01
categories: 
- tutorial
- heatwaves
--- 

# Implementing a heatwave index 

This tutorial constructs a workflow to identify the days where Maximum temperature &gt; 35 degrees AND Temperature difference &lt; 10 degrees 

This problem needs to be broken down into the following stages 

<ol>
<li>Get Minimum and Maximum temperature for Kaleen</li>
<li>Hot days = Maximum temperature &gt;35 degrees</li>
<li>Temperature difference = Maximum temperature - Minimum temperature</li>
<li>No relief days = Temperature difference &lt;10 degrees</li>
<li>Result = Hot days AND No relief days</li>
</ol>

The data is generated from a previous workflow, see the [Hello EWEDB (Simple Set Up the Swish Computer to connect to EWEDB) ](/2013/05/hello-ewedb/) tutorial.

The data file used is <span style="mso-fareast-language: EN-AU; mso-no-proof: yes;">&quot;C:\Swish\SampleData\Kaleen.csv&quot;</span>

![Image001](/images/HotDaysWithLittleReliefInKaleen001.png)

Creating a workflow

Open Kepler

![Image002](/images/HotDaysWithLittleReliefInKaleen002.png)

Find the &quot;Components panel&quot; on the left hand side of the Kepler window

![Image003](/images/HotDaysWithLittleReliefInKaleen003.png)

Add an actor: Locate the actor in the components panel.You can do this by typing the name of the actor in the "Search Components" field.<span style="mso-fareast-language: EN-AU; mso-no-proof: yes;">Locate the &quot;annotation" actor by searching for "annotation"</span>

<div class="MsoNormal">

<span style="mso-fareast-language: EN-AU; mso-no-proof: yes;">&nbsp;</span>![Image004](/images/HotDaysWithLittleReliefInKaleen004.png)</div>

<div class="MsoNormal">
<span style="mso-fareast-language: EN-AU; mso-no-proof: yes;">Add an annotation by dragging and dropping the icon from the panel to the workflow canvas on the right of the Kepler window.&nbsp;</span>

<span style="mso-fareast-language: EN-AU; mso-no-proof: yes;">![Image005](/images/HotDaysWithLittleReliefInKaleen005.png) </span></div>

<span style="mso-fareast-language: EN-AU; mso-no-proof: yes;">Use the annotation to describe the first step. O</span><span style="mso-fareast-language: EN-AU; mso-no-proof: yes;">pen the edit parameters dialog by double clicking on the annotation on the canvas. Enter the text "</span>Hot days = Maximum temperature &gt;35 degrees" into the "text" field and click the "Commit" button. The value will be displayed on the canvas

![Image006](/images/HotDaysWithLittleReliefInKaleen006.png)

The canvas will change to&nbsp; 

![Image007](/images/HotDaysWithLittleReliefInKaleen007.png)

Add a SDF director. 
 
Every workflow needs a single director to schedule the actors and links. It does not link to any other actor.

Without it you can not run the workflow. It is often good to run the work flow as you create it to find and fix any mistakes earlier than later. 
 
![Image008](/images/HotDaysWithLittleReliefInKaleen008.png)br />

Add the input data file name by searching for "string" and adding a "String Constant" actor to the workflow.

![Image009](/images/HotDaysWithLittleReliefInKaleen009.png)

Add <span style="mso-fareast-language: EN-AU; mso-no-proof: yes;">the input file name. Double click the string constant on the canvas and enter the text &quot;C:\Swish\SampleData\Kaleen.csv&quot; into the &quot;value:&quot; field and click the &quot;Commit&quot; button. </span>

![Image010](/images/HotDaysWithLittleReliefInKaleen010.png) 

<!--[if gte mso 9]><![endif]-->

<!--[if gte mso 9]><![endif]--><!--[if gte mso 9]><![endif]--><!--[if gte mso 10]>

<![endif]-->

<div class="MsoNormal" style="tab-stops: 135.75pt;">
Add a Greater than value actor to the right of the string constant. Click and drag from the output port (right most) on the string constant actor to the &quot;input&quot; port on the greater than actor. The link will snap to ports, and become a thicker line when connected. If you connect it to the wrong port: click on the line and press delete before trying again.</div>

![Image011](/images/HotDaysWithLittleReliefInKaleen011.png)

![Image012](/images/HotDaysWithLittleReliefInKaleen012.png)

Add values for the remaining ports. A workflow may not work if some inputs are not connected. 

<ul>
<li>VariableName : column to use from the input data, in this case "maxave"</li>
<li>Value : the left operand for the greater than operation, "35"</li>
<li>ResultVariableName : name given to the new column added to the data containing the result of maxave &gt; 35, "hot_days"</li>
</ul>

The workflow should look like 

![Image013](/images/HotDaysWithLittleReliefInKaleen013.png)

&nbsp;Save the work flow

&nbsp;![Image014](/images/HotDaysWithLittleReliefInKaleen014.png)

&nbsp;Kepler will ask you for a workflow name, enter "Hot days with little relief" and clink OK

![Image015](/images/HotDaysWithLittleReliefInKaleen015.png)

Choose a file location and save 

![Image016](/images/HotDaysWithLittleReliefInKaleen016.png)

&nbsp;Describe the second stage using another annotation

![Image017](/images/HotDaysWithLittleReliefInKaleen017.png)

Add a subtract variables actor.

Actors may have the term "Value" or "Variable" in there name. A value actor operates on a variable in the input data and a value given to the actor. A variable actor operates on two variables in the input data. Eg the subtract value actor may preform the operation "maxave" - 10, while subtract variables may preform&nbsp; "maxave" - "minave".

Link the input port to the same file name. Connect a link from the "input" port to the existing link to the file name.

![Image018](/images/HotDaysWithLittleReliefInKaleen018.png) 

This will automatically create a node that allows a link to split in two.

&nbsp;![Image019](/images/HotDaysWithLittleReliefInKaleen019.png)

Add values for the remaining ports.

<ul>
<li>LeftVariableName : "maxave" - This is the same "maxave" as before. It is possible to use the same value splitting the link, similarly to the input file name. Duplicating the value was chosen to make the workflow neater.</li>
<li>RightVariableName : "minave"</li>
<li>ResultVariableName : "temperature_difference"</li>
</ul>

The second part of the workflow should look like

![Image020](/images/HotDaysWithLittleReliefInKaleen020.png)

Move the canvas to an empty region to the right. Click and drag on the navigation panel to move the view of the canvas.

![Image021](/images/HotDaysWithLittleReliefInKaleen021.png)

Describe the third part of the workflow

![Image022](/images/HotDaysWithLittleReliefInKaleen022.png)

Add a less than value actor. Connect the input to the output of the second step. Make a link from the "output" port on the subtract variables actor to the "input" port of the less than value actor.

Input ports on SWISH actors may be connected to input file names or connected to the outputs of other SWISH actors.

&nbsp;![Image023](/images/HotDaysWithLittleReliefInKaleen023.png)

Add inputs

<ul>
<li>VariableName : connected to temperature_difference</li>
<li>ResultVariableName : "no_relief_days"</li>
</ul>

The workflow should look like

![Image024](/images/HotDaysWithLittleReliefInKaleen024.png) 

Part four. Part four need the output from part one.

To make neat long links you can use link nodes to guide link pathways. Add a link node by holding control and clinking&nbsp; on the canvas below part one.

![Image025](/images/HotDaysWithLittleReliefInKaleen025.png)

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ![Image026](/images/HotDaysWithLittleReliefInKaleen026.png) 

Link the output of part one to the nodes

![Image027](/images/HotDaysWithLittleReliefInKaleen027.png)

&nbsp;Add a second node below and to the left of part three. Continue the link, join the node to the&nbsp; previous node.

Add a merge tables actor,

<ul>
<li>Input1 : output of part one</li>
<li>Input2 : output of part three</li>
<li>Variable : "Date"</li>
</ul>
This will combine the results of part one with the results of part three using the date variable to match records.

Add an AND variables actor

<ul>
<li>Input : output of merge tables actor</li>
<li>LeftVariableName : "hot_days"</li>
<li>RightVariableName : "no_relief_days"</li>
<li>ResultVariableName : "result" </li>
</ul>

Add a save table actor.

To store the data calculated by the workflow you should save it somewhere specific using the save table actor. The file may be saved in a comma separated values format using a file name ending with ".csv" or may be saved in Stata format using a file name ending with ".dta".

<ul>
<li>&nbsp;Input : output of AND variables actor</li>
<li>FileName: "C:\Users\KeplerUser\Analysis\KaleenHotDaysWithLittleRelief.csv" - ie somewhere on your PC </li>
</ul>

Review the result using a display table actor

<ul>
<li>Input : output of save table actor</li>
</ul>

This part of the work flow should look like

![Image028](/images/HotDaysWithLittleReliefInKaleen028.png)

Specify the workflow to run once by setting the director iterations parameter to 1. Double click on the SDF director icon on the canvas, enter the the value "1" for iterations and click commit. Note infinite will run the workflow indefinitely.

Turn on animation at run time, this will show which actor is active while the workflow is running. Select the Animate at Runtime... menu option from the Tools menu.

![Image029](/images/HotDaysWithLittleReliefInKaleen029.png)

Enter the value 1 for Time (in ms) to hold highlight, and click Ok. Now when run, the workflow will highlight each actor with a red background.

If you haven't been saving regularly before running is a good time to do so.

To run the workflow click the green play button in the tool bar at the top of the window.

![Image030](/images/HotDaysWithLittleReliefInKaleen030.png)

The play button will remain highlighted until it is finished. While the workflow is running any changes made will not be displayed until it is finished. You can pause and stop execution, though it will wait until the currently running actor has completed before taking effect.

The workflow will end by saving the table to disk and displaying a simple summary view of the data.

![Image031](/images/HotDaysWithLittleReliefInKaleen031.png)

The final workflow should end up looking something like

![Image032](/images/HotDaysWithLittleReliefInKaleen032.png)

