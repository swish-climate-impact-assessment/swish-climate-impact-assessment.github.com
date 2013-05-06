# this script runs the ExtractAWAPGRIDS functions for sample locations
# depends on swishdbtools package from http:/swish-climate-impact-assessment.github.com
# eg 
workingdir <- "~/projects/swish-climate-impact-assessment.github.com/tools/ExtractAWAPdata4locations"
# eg 
fileName <-  "zones.xlsx"
# eg 
outputFileName <- "locations.shp"
# eg
outputDataFile <- "Kaleen.csv"
# eg
StartDate <- "2013-04-20" 
# eg
EndDate <- "2013-04-27" 
################################################################
# name: GeoCode
require(swishdbtools)
require(gisviz)
fileName <- file.path(workingdir, fileName)
towns <- read_file(fileName)
locations <- gGeoCode2(towns)
epsg <- make_EPSG()
df <- SpatialPointsDataFrame(cbind(locations$long,locations$lat),locations,                             
                             proj4string=CRS(epsg$prj4[epsg$code %in% "4283"])
                             )
setwd(workingdir)
if(file.exists(outputFileName))
{
  for(ext in c(".shp", ".shx", ".dbf", ".prj"))
  {
    file.remove(gsub(".shp",ext,outputFileName))
  }
}
writeOGR(df,outputFileName,gsub(".shp","",outputFileName),"ESRI Shapefile")
tempTableName <- outputFileName

################################################################
# name: send2postgis
require(swishdbtools)
ch <- connect2postgres2("ewedb")
locations <- read_file(file.path(workingdir,tempTableName))
locations <- locations@data
tempTableName <- swish_temptable()
dbWriteTable(ch, tempTableName$table, locations, row.names = F)
tested <- sql_subset(ch, tempTableName$fullname, eval = T)
#tested
tempTableName <- tempTableName$fullname
tempTableName

# points2geom
sch <- strsplit(tempTableName, "\\.")[[1]][1]
tbl <- strsplit(tempTableName, "\\.")[[1]][2]
sql <- points2geom(
  schema=sch,
  tablename=tbl,
  col_lat= "lat",col_long="long", srid="4283"
)
# cat(sql)
dbSendQuery(ch, sql)
tbl

################################################################
# name: R_raster_extract_by_day
require(swishdbtools)
require(awaptools)
require(reshape)
tempTableName_locations <- tbl
startdate <- StartDate
enddate <- EndDate
ch<-connect2postgres2("ewedb")
tempTableName <- swish_temptable("ewedb")

raster_extract_by_day(ch, startdate, enddate,
                      schemaName = tempTableName$schema,
                      tableName = tempTableName$table,
                      pointsLayer = tempTableName_locations,
                      measures = c("maxave", "minave")
)

output_data <- reformat_awap_data(
  tableName = tempTableName$fullname
)

outputDataFile <- file.path(workingdir, outputDataFile)
write.csv(output_data,outputDataFile, row.names = FALSE)
outputFileName <- outputDataFile
outputFileName


################################################################
# name: tidy up
require(swishdbtools)
ch<-connect2postgres2("ewedb")
sch <- swish_temptable("ewedb")
sch <- sch$schema
tbls <- pgListTables(ch, sch, table="foo", match = FALSE)
for(tab in tbls[,1])
{
  dbSendQuery(ch, 
              sprintf("drop table %s.%s", sch, tab)
  )
}
