---
name: 2013-04-26-extract-weather-from-grids
layout: post
title: Extracting Weather Data from Grids
---

# Gridded weather Data
One of the cornerstone datasets in the EWEDB is the gridded weather data from the [Australian Bureau of Meteorology](http://www.bom.gov.au).

## Step one: find the data
### First log in to the Web Catalogue
![extract-data-login-ddiindex.png](/images/extract-data-login-ddiindex.png)
### Then Browse 
![extract-data-browse.png](/images/extract-data-browse.png)
### Or Search
![extract-data-search.png](/images/extract-data-search.png)

## Step two: Create a Kepler Workflow

The Workflow in the image below:
- gets a list of study locations in the towns.xlsx file
- subsets them to the places of interest
- geocodes them using the google geocoder
- uploads them to the EWEDB PostGIS server (after checking our saved password in the postgres.conf file)
- extracts the pixel values for the raster named in the string constant (that we found from the catalogue)
![extract-data-kepler.png](/images/extract-data-kepler.png)
## The result
The result is a file extracted from the database to the local TEMP directory and the name is shown.
![extract-data-kepler-ran.png](/images/extract-data-kepler-ran.png)
The user can then take these data for further work
![extract-data-result.png](/images/extract-data-result.png)
