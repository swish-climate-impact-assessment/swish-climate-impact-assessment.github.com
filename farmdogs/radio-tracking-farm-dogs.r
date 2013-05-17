
# this script runs the ExtractAWAPGRIDS functions for sample locations
# depends on swishdbtools and awaptools package from http:/swish-climate-impact-assessment.github.com

################################################################
# name:R_download-google-ssheet
# eg
url <-
 "https://docs.google.com/spreadsheet/pub?key=0AjrmPjvc7LwOdFowTzJ2T2xsa1pkeVdRd3VlQjZtdHc&output=csv"
# eg
outputFileName <- "locations.dta"
# eg
workingdir <- "~/projects/radio-tracking-collars"
require(RCurl)
require(foreign)
d <- read.csv(textConnection(getURLContent(url)))
#str(d)
#summary(d)
names(d)  <- tolower(names(d))
# add a primary key 
d$fid <- 1:nrow(d)
write.dta(d, file.path(workingdir,outputFileName))
tempTableName <- outputFileName
tempTableName

################################################################
# name:visualize-points-layer
require(maps)
require(swishdbtools)
inputfilepath  <- file.path(workingdir,tempTableName)
locations <- read_file(inputfilepath)
head(locations)
plot(locations$long, locations$lat)
map.scale(ratio=F)

################################################################
# name: send2postgis
require(swishdbtools)
ch <- connect2postgres2("ewedb")
inputfilepath  <- file.path(workingdir,tempTableName)
locations <- read_file(inputfilepath)
if(get_file_extension(inputfilepath) == "shp")
  {
    locations <- locations@data
  }

tempTableName <- swish_temptable()
dbWriteTable(ch, tempTableName$table, locations, row.names = F)
# d <- sql_subset(ch, tempTableName$fullname, eval = T)
# head(d)
#tempTableName <- tempTableName$fullname
#tempTableName

# points2geom
sql <- points2geom(
  schema=tempTableName$schema,
  tablename=tempTableName$table,
  col_lat= "lat",col_long="long", srid="4283"
)
# cat(sql)
dbSendQuery(ch, sql)
tbl  <- tempTableName$table
tbl

################################################################
# name: R_raster_extract_by_day
# eg 
weatherVariables <- "c('maxave', 'minave', 'totals', 'vprph09' , 'vprph15')"
weatherVariables  <- eval(parse(text = weatherVariables))
# eg
zoneLabel <- "fid"
# eg
StartDate  <- "2013-01-01"
# eg
EndDate  <- "2013-01-01"
# eg
outputDataFile  <- "weather.csv"
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
                      measures = weatherVariables,
                      zone_label = zoneLabel
)

output_data <- reformat_awap_data(
  tableName = tempTableName$fullname, zone_label = zoneLabel
)

outputDataFile <- file.path(workingdir, outputDataFile)
write.csv(output_data,outputDataFile, row.names = FALSE)
fileName2 <- outputDataFile
fileName2

################################################################
# name:merge-locations-with-time-data
                                        # workingdir
# eg 
fileName1 <- outputFileName
fileName1 <- file.path(workingdir, fileName1)
# eg 
fileName2 <- outputDataFile
# eg
tempFileName <- "weather-merged-latlong.csv"
tempFileName <- file.path(workingdir,tempFileName)
# eg
byCols <- "c('fid')"

require(swishdbtools)
f1 <- read_file(fileName1)
f2 <- read_file(fileName2)
byCols <- byCols
df <- eval(
  parse(
    text = 
      sprintf(
      "merge(x = %s, y = %s, by = %s)","f1","f2", byCols
      )
    )
  )
#tempFileName <- tempfile("foo", tmpdir = Sys.getenv("TEMP"), fileext = ".csv")
write.csv(df, tempFileName, row.names=FALSE)
tempFileName

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
