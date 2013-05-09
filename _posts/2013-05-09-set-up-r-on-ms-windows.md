---
name: set-up-r-for-kepler-on-ms-windows
layout: post
title: Set Up R for Kepler on MS Windows
date: 2013-05-09
categories:
- set up your environment
---
  
## Install R 3.0 
Even if you have [The R Environment for Statistical Computing and Graphics](http://www.r-project.org/) installed we recommend you upgrade to version 3.0 because new packages from there will not work with R 2.15 etc.

## Register R in the PATH so that Kepler can find it
This tutorial assumes windows 7 and a user without administrator privileges.

![setup-r-Slide1.PNG](/images/setup-r-Slide1.PNG)

## First download and install R to a location you can write to

![setup-r-Slide2.PNG](/images/setup-r-Slide2.PNG)

## It won't be recognised on your PATH
Because you are not admin it will not be in your path.  Check this by opening the terminal (Run > cmd) and then type R.

![setup-r-Slide3.PNG](/images/setup-r-Slide3.PNG)

## Go to the control panel and navigate to the set environment variables

![setup-r-Slide4.PNG](/images/setup-r-Slide4.PNG)

## make a new USER variable 

![setup-r-Slide5.PNG](/images/setup-r-Slide5.PNG)

## Locate the appropriate R binaries

![setup-r-Slide6.PNG](/images/setup-r-Slide6.PNG)

## make the new variable called Path

![setup-r-Slide7.PNG](/images/setup-r-Slide7.PNG)

## Exit and restart the terminal and check that R is recognised

![setup-r-Slide8.PNG](/images/setup-r-Slide8.PNG)

## The End
