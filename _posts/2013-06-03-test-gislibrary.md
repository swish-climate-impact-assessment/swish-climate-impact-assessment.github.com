---
name: 2013-06-03-test-gislibrary
layout: post
title: test gislibrary
date: 2013-06-03
---

# Testing the GIS library from R

require(devtools)
install_github("swishdbtools", "swish-climate-impact-assessment")
require(swishdbtools)
install_github("gisviz", "ivanhanigan")
require(gisviz)
ch <- connect2postgres2("gislibrary")
dbGetQuery(ch, 
           "select t1.sla_code, t2.sla02_code as s2 
           from abs_sla.actsla01 t1 join abs_sla.actsla02 t2 
           on t1.sla_code = t2.sla02_code;
           ")
# 
sql <- postgis_concordance(conn = ch, source_table = "abs_sla.actsla01", source_zones_code = 'sla_code', target_table = "abs_sla.actsla02", 
          target_zones_code = "sla02_code", into = paste("public.concordance",sep = ""), tolerance = 0.01, subset_target_table = NA, 
          eval = F) 
cat(sql)
# which gives me something a little less pretty
dbSendQuery(ch,
"
select source_zone_code, source_zones, 
  target_fid, target_zone_code, prop_olap_src_of_tgt,
            prop_olap_src_segment_of_src_orig, geom
            into public.concordance
            from
            (
            select    src.zone_code as source_zone_code,
            tgt.gid as target_fid, tgt.zone_code as target_zone_code, source_zones,
            st_intersection(src.geom, tgt.geom) as geom,
            st_area(src.geom) as src_area,
            st_area(tgt.geom) as tgt_area,
            st_area(st_intersection(src.geom, tgt.geom )) as area_overlap,
            st_area(st_intersection(src.geom, tgt.geom
            ))/st_area(tgt.geom) as
            prop_olap_src_of_tgt,
            st_area(st_intersection(src.geom, tgt.geom
            ))/st_area(src.geom) as
            prop_olap_src_segment_of_src_orig
            from
            (
            select sla_code as zone_code, cast('abs_sla.actsla01' as text) as source_zones, geom
            from abs_sla.actsla01
            ) src,
            (
            select gid, sla02_code as zone_code, geom
            from abs_sla.actsla02
            ) tgt
            where st_intersects(src.geom, tgt.geom)
            ) concorded
            where prop_olap_src_of_tgt > 0.01;
            grant select on public.concordance to public_group;                        
            alter table public.concordance add column gid serial primary key;                        
            ALTER TABLE public.concordance ALTER COLUMN geom SET NOT NULL;                        
            CREATE INDEX concordance_gist on public.concordance using GIST(geom);                      
            ALTER TABLE public.concordance CLUSTER ON concordance_gist;
")
# or just 
# dbSendQuery(ch, sql)
# if I don't want to look at the ugly code
# so now I can use QGIS to visualise this, or if on linux rgdal can access it
pwd <- getPassword()
shp <- readOGR2(hostip="130.56.60.77",user="gislibrary",db="gislibrary", layer="concordance", p = pwd)
head(shp@data)
choropleth(stat="prop_olap_src_of_tgt", region.map=shp, scalebar = T)
# and finally just clean up the temp file from the db
dbSendQuery(ch, "drop table  public.concordance")
