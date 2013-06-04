# ---
# name: 2013-06-03-test-gislibrary
# layout: post
# title: test gislibrary
# date: 2013-06-03
# ---

# Testing the GIS library from R

require(devtools)
install_github("swishdbtools", "swish-climate-impact-assessment")
require(swishdbtools)
install_github("gisviz", "ivanhanigan")
require(gisviz)
ch <- connect2postgres2("gislibrary")
# fill in the details, only required once as will save to your profile
dbGetQuery(ch, 
           "select t1.sla_id, t2.sla_code as s2, st_area(t1.geom)
           from abs_sla.nswsla91 t1 join abs_sla.nswsla01 t2 
           on t1.sla_id = 1 || substr(cast(t2.sla_code as text), 6,9);
           ")

sql <- postgis_concordance(conn = ch, source_table = "abs_sla.nswsla91",
       source_zones_code = 'sla_id', target_table = "abs_sla.nswsla01",
       target_zones_code = "sla_code",
       into = "public.concordance", tolerance = 0.01,
       subset_target_table = "cast(sla_code as text) like '105%'", 
       eval = F) 
cat(sql)


dbSendQuery(ch, sql)

pwd <- getPassword()
shp <- readOGR2(hostip="130.56.60.77",user="gislibrary",
       db="gislibrary", layer="concordance", p = pwd)
choropleth(stat="prop_olap_src_segment_of_src_orig", region.map=shp, scalebar = T, probs = seq(0, 1, .2), invert.brew.pal= F, maptitle='Sydney SLA91-01 intersection')

dbSendQuery(ch, "drop table  public.concordance")
