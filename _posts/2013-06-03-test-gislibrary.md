---
name: 2013-06-03-test-gislibrary
layout: post
title: test gislibrary
date: 2013-06-03
---

# Testing the GIS library from R
In this post we will use the swish R/PostGIS tools to manipulate spatial data on a remote GIS server and extract the result to our local client machine.

The great thing about PostGIS is that it is a standard relational database that also understands spatial data.  We have developed [an R package called swishdbtools](http://swish-climate-impact-assessment.github.io/tools/swishdbtools/swishdbtools-downloads.html) to assist connecting to the Database from Kepler.

    require(swishdbtools)
    ch <- connect2postgres2("gislibrary")
    # fill in the details, only required once as will save to your profile
    dbGetQuery(ch, 
           "select t1.sla_id, t2.sla_code as s2, st_area(t1.geom)
           from abs_sla.nswsla91 t1 join abs_sla.nswsla01 t2 
           on t1.sla_id = 1 || substr(cast(t2.sla_code as text), 6,9);
           ")

Pretty cool huh?  Spatial functions start with st and the generic name for the spatial data is geom or the_geom.

## say we want to create a concordance file to map changes between SLA boundaries
I figured out a complicated SQL syntax to compute the intersecting geometries, then wrapped it up into an R function:


    sql <- postgis_concordance(conn = ch, source_table = "abs_sla.nswsla91",
       source_zones_code = 'sla_id', target_table = "abs_sla.nswsla01",
       target_zones_code = "sla_code",
       into = paste("public.concordance",sep = ""), tolerance = 0.01,
       subset_target_table = "cast(sla_code as text) like '105%'", 
       eval = F) 
    cat(sql)


## which gives me something a little less pretty
so I just run the single line version

    dbSendQuery(ch, sql)
    
if I don't want to look at the ugly code

## so now I can use QGIS to visualise this, or if on linux rgdal can access it
    install_github("gisviz", "ivanhanigan")
    require(gisviz)
    pwd <- getPassword()
    shp <- readOGR2(hostip="130.56.60.77",user="gislibrary",
           db="gislibrary", layer="concordance", p = pwd)
    choropleth(stat="prop_olap_src_segment_of_src_orig", region.map=shp, 
      scalebar = T, probs = seq(0, 1, .2), invert.brew.pal= F, 
      maptitle='Sydney SLA91-01 intersection'
      )
      
## Which gives the map
This shows the SLAs that existed in 2001 that were a smaller segment of their original SLA zone in 1991 (the red areas changed the most).

![nswconc.png](/images/nswconc.png)

## and finally just clean up the temp file from the db

    dbSendQuery(ch, "drop table  public.concordance")
