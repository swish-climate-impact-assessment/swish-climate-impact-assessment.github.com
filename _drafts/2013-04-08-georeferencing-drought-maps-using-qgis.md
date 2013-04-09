--- 
name: georeferencing-drought-maps-using-qgis
layout: post
title: Georeferencing Drought Maps using QGIS
date: 2013-04-08
categories: 
- GIS
- drought
---

# Introduction
Drought Declarations are made by government in Australia to determine when and where a drought is occuring.
The Declarations are linked to agricultural and social support policies. We are working on a climatic drought index that should correlate with these Drought Declarations.  The New South Wales Government has provided us with spatial data from 1986 but they also have a graphical visualisation available for earlier times, especially noteworthy is the extreme 1982-1983 drought.
This post is a document of the process I will try to derive spatial data from the image.
# Data
Download the drought maps. The current maps are at:
[http://www.dpi.nsw.gov.au/agriculture/emergency/drought/planning/climate/advance-retreat] [1]

But there is a higher resolution map archived at:
[http://pandora.nla.gov.au/pan/120345/20120529-0000/advance-retreat-drought-map-april-2011.pdf] [2]

# Method
## Plan
Try out the method on a month that is already available as spatial data, to assess precision.

Then start mapping earlier data with no correlates.

## Step 1 - load the reference layer
Load up the NSW boundaries by selecting "Add PostGIS Layers" > Connect > gislibrary
![qgis-postgis](/images/qgis-postgis.png)

Then select a map layer of NSW
![load-nswsla86](/images/load-nswsla86.png)

## Step 2 - load the raster data into the Georeferencer
Launch the Georeferencer from Raster > Georeferencer > Georeferencer.


# Results

# Conclusion

[1]: http://www.dpi.nsw.gov.au/agriculture/emergency/drought/planning/climate/advance-retreat
[2]: http://pandora.nla.gov.au/pan/120345/20120529-0000/advance-retreat-drought-map-april-2011.pdf
