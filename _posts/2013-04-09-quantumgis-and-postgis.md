--- 
name: quantumgis-and-postgis
layout: post
title: QuantumGIS and PostGIS
date: 2013-04-09
categories: 
- GIS
---

# Introduction
This post is explains how to get spatial data from a PostGIS server using QuantumGIS (QGIS).

# Method
Open up QGIS "Add PostGIS Layers".

![qgis-postgis](/images/qgis-postgis.png)

Click "New" and enter the details as shown, if "Test" is OK then hit "OK".

Note that the options to "only look in geometry_columns" and "use estimated metadata" may speed up communications from the server, but in some cases restrict access to the full list of available tables.  Experiment with these settings by hitting "Edit" and modifying as suits.

PS The first time you set up the connection there will be a warning about saving your password.  Take a moment to consider the risk this poses to data.

![qgis-postgis-new](/images/qgis-postgis-new.png)

Select the layer(s) from this list.

![qgis-postgis-getdata](/images/qgis-postgis-getdata.png)

Right click on the layer and select "Save as".

![qgis-postgis-saveas1](/images/qgis-postgis-saveas1.png)

Browse to the local folder to store the data in, and give the shapefile a name.

![qgis-postgis-saveas2](/images/qgis-postgis-saveas2.png)

# Conclusion
This is an appropriate method to download a single vector layer at a time.  If a raster layer is needed or if a bulk download of many vector layers is desired, then other tools called "pgsql2shp" and "readGDAL" are more efficient.  A future post will describe these methods, and SWISH Kepler Actors that we build to perform these tasks.
