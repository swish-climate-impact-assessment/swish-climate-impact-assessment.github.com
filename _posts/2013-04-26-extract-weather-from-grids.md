---
name: 2013-04-26-extract-weather-from-grids
layout: post
title: Extracting Weather Data from Grids
categories:
- awap
- extract
---

# Gridded weather Data
One of the cornerstone datasets in the EWEDB is the gridded weather data from the [Australian Bureau of Meteorology](http://www.bom.gov.au).  This post will describe a user extracting weather data for their study locations from overlaying the coordinates on a grid and returning the value of the pixels at that location for a specified date.

## Step one: find the data
### First log in to the Web Catalogue

![extract-data-login-ddiindex.png](/images/extract-data-login-ddiindex.png)

### Then Browse 

![extract-data-browse.png](/images/extract-data-browse.png)

### Or Search

![extract-data-search.png](/images/extract-data-search.png)

### These data are discovered.  Further information is available.

![extract-data-search-result.png](/images/extract-data-search-result.png)

## Step two: Create a Kepler Workflow

The Workflow in the image below:

- gets a list of study locations in the towns.xlsx file (Notice that Wolongong is MISSPELT?)
- subsets them to the places of interest
- geocodes them using the google geocoder (which will return a fuzzy logic best match for the misspelt name - thanks Google!)
- uploads the coordinate data (in latitude and longitude) to the EWEDB PostGIS server (after checking our saved password in the postgres.conf file)
- tells the PostGIS data are a points vector datatype, and that the coordinates are in GDA 1994 projection system
- extracts the pixel values for the raster named in the string constant (that we found from the catalogue)

![setup-swish-Slide8.PNG](/images/setup-swish-Slide8.PNG)

![extract-data-kepler.png](/images/extract-data-kepler.png)

## The result
The result is a file extracted from the database to the local TEMP directory and the name is shown.

![setup-swish-Slide13.PNG](/images/setup-swish-Slide13.PNG)

The user can then take these data for further work

![setup-swish-Slide14.PNG](/images/setup-swish-Slide14.PNG)  

## Quality Control
An imporant point to note is that the coordinates retrieved from the GoogleMaps geocoder might not be correct.  It is easy to check that the locations we just stored in the database are correct by viewing them in Quantum GIS (see [this previous post](/2013/04/quantumgis-and-postgis) for instructions on setting up Quantum GIS).

![setup-swish-Slide15.PNG](/images/setup-swish-Slide15.PNG)

![setup-swish-Slide16.PNG](/images/setup-swish-Slide16.PNG)

Thankfully these locations appear good (even the mis-spelt "Wolongong").
