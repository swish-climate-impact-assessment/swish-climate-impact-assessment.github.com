# this script runs the ExtractAWAPGRIDS functions for sample locations
workingdir <- "/home/ivan_hanigan/projects/swish-climate-impact-assessment.github.com/tools/ExtractAWAPdata4locations"
fileName <- file.path(workingdir, "zones.xlsx")
# depends on swishdbtools package from http:/swish-climate-impact-assessment.github.com

################################################################
# name: GeoCode_and_send2postgis
require(swishdbtools)
require(gisviz)
ch <- connect2postgres2("ewedb")
towns <- read_file(fileName)
locations <- gGeoCode2(towns)
tempTableName <- swish_temptable()
dbWriteTable(ch, tempTableName$table, locations, row.names = F)
tested <- sql_subset(ch, tempTableName$fullname, eval = T)
#tested
tempTableName <- tempTableName$fullname
tempTableName

################################################################
# name: points2geom
require(swishdbtools)
ch <- connect2postgres2("ewedb")
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
startdate <- "2013-04-20" #StartDate
enddate <- "2013-04-27" #EndDate
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

outputFileName <- file.path(workingdir, "Kaleen.csv")
write.csv(output_data,outputFileName, row.names = FALSE)
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