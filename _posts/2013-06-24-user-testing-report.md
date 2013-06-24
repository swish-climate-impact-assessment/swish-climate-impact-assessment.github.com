---
name: User testing report
layout: post
title: AddinUser testing report
date: 2013-06-24
categories:
- User testing report
---
  
# SWISH Kepler actors user testing.
We invited Peter Manger from the Fenner School at the ANU to be one of our test users. Peter has a background in simulation, modelling and software. He is a good example of someone proficient with data processing and analysis but with no previous exposure to SWISH tools.

# How well did the user use SWISH?
Peter made his way through the tutorial, quicker than I expected for someone who had never used the software before. 

## During the testing two mistakes occurred
1. A missing an input link to an actor. When run the workflow reported an error, Peter quickly identified the omission himself and corrected it.
2. The identifier “Date” was used with a capital letters instead of “date”. When run Kepler reported an error message; however this problem was too subtle. Even after I pointed it out Peter was unclear as to why the error was occurring.

The images in the tutorial provided the necessary details to continue through the tutorial without encouraging Peter to notice and understand the accompanying text. The tutorial explains that the all links need to be connected for the workflow to run and the identifiers are the names of columns in the input data. Both of these points that directly explained the errors that occurred where overlooked. 

# Did the user complete the analysis they intended to do?  
Yes!, Peter successfully assembled an operational workflow that ran and produced the correct result by following the tutorial. 

Peter was then curious and started to ‘play’ with values in the heat index calculation. He lowered the maximum temperature limit and increased the min – max threshold to generate a greater number of ‘heat waves’.

# What features did they find useful and what features did they have difficulty with or wish to see (and are subject to future improvement if there are available resources)?
Peter was able to quickly use the installer and update the software to the latest version of SWISH actors. Peter found the drag, drop and link nature of Kepler intuitive and usable. He was able to easily find all the actors needed by the tutorial. The actors used where clearly named and labelled, Peter found them simple to use.

The biggest problem is the handling of errors. The SWISH actors that use Stata report their own error messages. The SWISH actors that use R do not report any error messages other than the fact an error has occurred. General Kepler actors report the Java stack trace from where the error occurred in Kepler source code.

** None of these are useful to the user and could be improved. **

The error reported by the Stata based actors indicate the error that Stata had, but it is always a consequence of a problem located somewhere in the lead up to running Stata. The error messages require an intimate understanding of how SWISH operates to decode. 

The R errors are completely opaque and provide no useful information.

General Kepler errors are also cryptic and not helpful. 

Error handling for general Kepler actors is the responsibility of the developers of the actors and Kepler to manage. The SWISH Stata actors, although they perform their own error checking and reporting would improve the user experience dramatically by reporting more meaningful messages and solutions to the user. The SWISH R actors are completely lacking in any form of error handling and need to implement it within the R code its self. 

# Observations

Peter had trouble linking some actors together as the links ‘snap’ to other nearby links or port. Peter worked around this when necessary by dragging links the long way round to avoid connecting to the wrong place. 

Peter did not run the workflow until the very end. This made finding errors more difficult.

Peter did not realise that by creating and using the workflow in the tutorial he was using the statistical software Stata.

The understanding Peter gained from the tutorial was mainly operational details of how to use Kepler. 

# Peters feedback		

Peter knew that Kepler was existing software but was unclear what part of the exercise corresponded to SWISH project. His suggestion was to package all the actors available in a SWISH subgroup of some kind.

Peter liked the images, and found the progression from individual small steps at the start of the tutorial to boarder instructions at the end made sense. 

