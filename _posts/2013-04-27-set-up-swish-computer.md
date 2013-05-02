---
name: set-up-swish-computer
layout: post
title: Set Up your Swish Computer to connect to EWEDB
date: 2013-04-27
categories:
- set up
- connecting
---

## Install SWISH Database Tools R package
In this tutorial the swishdbtools package will be set up so that you can connect to the EWEDB using the R tools we developed to allow your username and password to be used by [the SWISH Kepler actors](https://github.com/swish-climate-impact-assessment/swish-kepler-actors).  

### An important note is that whilst not a requirement there are a lot of the Kepler Project's features which use the R language and so this requires that R be on the users PATH.  

The process shown below is on Windows XP with R 2.15.0 and has been tested with Ubuntu 12.04 with R 2.15.2 (but NOT TESTED ON MAC).

We will install the necessary R package with the Database Drivers in it, and then the package is designed to also assist you to store a private copy of your username and password inside your profile on your computer.  This will be in a file called [.pgpass on linux and pgpass.conf on windows](http://www.postgresql.org/docs/current/static/libpq-pgpass.html).  On Microsoft Windows the file is named %APPDATA%\postgresql\pgpass.conf (where %APPDATA% refers to the Application Data subdirectory in the user's profile).  
  
OPTIONALLY on Linux (for full functionality with psql)  the permissions on .pgpass must disallow any access to world or group; achieve this by the command:

    sudo chmod 0600 ~/.pgpass
<p></p>
## Install the package binary file
There are two main options.  Either install with devtools (if on windows you'll need Rtools installed):

    require(devtools)
    install_github("swishdbtools", "swish-climate-impact-assessment")
    require(swishdbtools) 
<p></p> 
OR download the package binaries from [the SWISH downloads page](http://swish-climate-impact-assessment.github.io/tools/swishdbtools/swishdbtools-downloads.html) and install using R.  The Rstudio software is shown here:

![setup-swish-Slide1.PNG](/images/setup-swish-Slide1.PNG)

## Browse to the downloads

![setup-swish-Slide2.PNG](/images/setup-swish-Slide2.PNG)

## Install SWISH Database Tools R package Dependencies:
The swishdbtools package is still in development and is not on CRAN so you will need to sort out the dependencies yourself.  

You can install all the dependencies with something like:

    install.packages(c("foreign", "rgdal", "plyr", "RODBC", "XLConnect"))
    require(swishdbtools)
  <p></p>
OR if you don't want the newest versions

    if (length(grep("ming", sessionInfo()[[1]]$os)) == 1) {
      download.file("http://swish-climate-impact-assessment.github.io/tools/swishdbtools/swishdbtools_1.2.zip", 
                    destfile=file.path(Sys.getenv("HOME"), "swishdbtools_1.2.zip"), 
                    mode="wb")
      install.packages(file.path(Sys.getenv("HOME"), "swishdbtools_1.2.zip"), repos = NULL)
    } else {
      download.file("http://swish-climate-impact-assessment.github.io/tools/swishdbtools/swishdbtools_1.2_R_x86_64-pc-linux-gnu.tar.gz", 
                    destfile=file.path(Sys.getenv("HOME"), "swishdbtools_1.2_R_x86_64-pc-linux-gnu.tar.gz"), 
                    mode="wb")
      install.packages(file.path(Sys.getenv("HOME"), "swishdbtools_1.2_R_x86_64-pc-linux-gnu.tar.gz"), repos = NULL)
    }
    if(!require(foreign))   install.packages("foreign", repos="http://cran.csiro.au/"); require(foreign)
    if(!require(rgdal))     install.packages("rgdal", repos="http://cran.csiro.au/");     require(rgdal)  
    if(!require(plyr))        install.packages("plyr", repos="http://cran.csiro.au/");      require(plyr)
    if(!require(RODBC))       install.packages("RODBC", repos="http://cran.csiro.au/");     require(RODBC)
    if(!require(XLConnect)) install.packages("XLConnect", repos="http://cran.csiro.au/"); require(XLConnect)
    require(swishdbtools)
    ch <- connect2postgres2("ewedb")
    sql_subset(ch, "dbsize", limit = 1, eval = T)
<p></p>

## Installing dependencies

![setup-swish-Slide3.PNG](/images/setup-swish-Slide3.PNG)

## should not have any ERRORS (but may have a few WARNINGS)

![setup-swish-Slide4.PNG](/images/setup-swish-Slide4.PNG)
  
![setup-swish-Slide7.PNG](/images/setup-swish-Slide7.PNG)

## While we are here, let's install Ivan's GisViz package so we run the [SWISH geocoder workflow](http://swish-climate-impact-assessment.github.io/tools/geocoder/geocoder.html) as a TEST

The SWISH project has developed a [simple geocoder workflow](http://swish-climate-impact-assessment.github.io/tools/geocoder/geocoder.html) to assist our users to get going on a climate/health analysis. This depends on Ivan Hanigan's [GisViz package](http://ivanhanigan.github.io/gisviz/) so let's download and install that now.
 
## Download the binary and use Rstudio to browse to the downloaded file

![setup-swish-Slide5.PNG](/images/setup-swish-Slide5.PNG)

## Again we need to install the dependencies (when the packages are on CRAN this will be automatic)

    install.packages(
                      c("RCurl", "XML", "ggmap", "maps", 
                      "maptools", "RColorBrewer", "spdep", "rgdal")
                    )
    require(gisviz)
<p></p>
![setup-swish-Slide6.PNG](/images/setup-swish-Slide6.PNG)

## Get the SWISH geocoder workflow from [this webpage](http://swish-climate-impact-assessment.github.io/tools/geocoder/geocoder.html)
This is from version 2.4.  If you open this with Kepler 2.3 and don't want to upgrade, tell it to Force Open, then skip element and once open edit the SDF director and change AUTO to 1.

To demonstrate the geocoder at work let's create some dummy data.  In a spreadsheet I've typed the names of a few towns in New South Wales. This uses the [GoogleMaps geocoding API (with HTTPS security)](https://developers.google.com/maps/documentation/geocoding) which is very clever at resolving place names using fuzzy logic.  To demonstrate this I have misspelt the name of the well-known city Wollongong, leaving off one of the L's and expect google maps to return the correct coordinates anyway. 

![setup-swish-Slide8.PNG](/images/setup-swish-Slide8.PNG)

## Modify the input file name to reflect the location of your spreadsheet

![setup-swish-Slide18.PNG](/images/setup-swish-Slide18.PNG)

## when you run this it will look for your PostGIS username and password, or ask you to enter them (ON WINDOWS THE POPUP BOX IS OFTEN BEHIND OTHER WINDOWS)

You will have recieved a username and password when the Data Manager set up your account.

![setup-swish-Slide10.PNG](/images/setup-swish-Slide10.PNG)

![setup-swish-Slide11.PNG](/images/setup-swish-Slide11.PNG)

## your details are now stored in this file.
(or ~/.pgpass on Linux) 

![setup-swish-Slide12.PNG](/images/setup-swish-Slide12.PNG)
  
## One thing this workflow does after geocoding the locations and storing a local shapefile is make a default map

![setup-swish-Slide19.PNG](/images/setup-swish-Slide19.PNG)

## But of more interest to us is the data it sent to the PostGIS database that we can view with Quantum GIS
  
![setup-swish-Slide15.PNG](/images/setup-swish-Slide15.PNG)
 
![setup-swish-Slide16.PNG](/images/setup-swish-Slide16.PNG)
  


## The End
From here the interested reader can follow up on what that workflow does in [this previous post](/2013/04/extract-weather-from-grids/)
