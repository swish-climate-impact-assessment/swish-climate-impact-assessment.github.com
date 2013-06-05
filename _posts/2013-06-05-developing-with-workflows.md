---
name: 2013-06-05-developing-with-workflows
layout: post
title: Developing new tools with Kepler workflows
---

## Developing new tools with Kepler workflows
If you can't get an actor from the core Kepler actors or our SWISH actor contributions then you have two choices:
- assemble current actors into a new 'composite' actor or
- develop a R/python/matlab/stata function to be a new actor.

If you go for option 2 therefore you have to develop your function to work with other Kepler actors.    There are a few tricks to doing this.  This post will show several different approaches available to develop a new Kepler R actor.

## 1 identify R function
There is probably an R function that does what you want.  If not start writing one.  If it is a really simple case of just using a current R function with simple input/output requirements you can write it straight into the Rexpression actor and add some ports... however anything more than a couple of lines can get buggy quickly, and this is not a good place to be debugging code.

## 2 write function in a script
Then , test/debug in an IDE like emacs, Rstudio or eclipse; and then deploy to Rexpression actor in workflow

## 3 source() your script from kepler
Similar to 2 but rather than copy the code to the actor just add 

    source('path/to/script.R')

<p><\p>
to the actor.

## 4 write a package
Similar to 2 and 3 but the function is written to a package and then this is loaded with

    require(MyPackage)
    outputPortValue <- myFunction(inputPortValue, otherArgument)
    outputPortValue

You can then publish this on GitHub or CRAN, or even just send as a zip or tar to your collaborators.

## 5 add this to MyWorkflows
if you have the R code or package details in the actor save this by right clicking on the actor and save it to your kepler directory under MyWorkflows.  This means it will be available whenever you open Kepler.

## 6 If it is really awesome contribute it to SWISH
Take a fork of the swish-kepler-actors GitHub repo and add your actor and tests to the simpleInstaller/Actors folder. Then send a pull request to the SWISH maintainers and these will then be incorporated into our one-click installer.
