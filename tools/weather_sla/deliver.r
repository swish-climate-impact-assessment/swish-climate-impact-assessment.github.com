# This workflow will deliver weather data from the EWEDB to a local directory.
# Ivan Hanigan 2012-12-14

# README:
#   Running this workflow the first time will cause a GUI box to
#   appear for your details and password will be saved in plain text
#   to your profile.
# Sometimes this GUI box is behind other windows.
#
# Either change the inputs above, or set interactively to TRUE.
# In interactively mode a GUI box will open where you can change the values,
# or leave blank to accept the defaults.
# NB interactivity is a test.  it is not favoured in swish due to the
# lack of reproducibility.  consider the fgui:guiv code as legacy
# code, deprecated.
#
# NB dates need quotation marks if using the GUI box.
#
# TODO:
#   There are missing days in  solarave, vprph09, vprph15.
# Try downloading again to see if fixed now.
# Add the population weighted averaging approach.

if(!require(swishdbtools)) print('Please download the swishdbtools package and install it.')
# for instance
# install.packages("~/tools/swishdbtools_1.0_R_x86_64-pc-linux-gnu.tar.gz", repos = NULL, type = "source");
require(swishdbtools)


# # user definitions, or setup interactively
# database <- 'ewedb'
# spatialzones <- 'SD'
# outdir <- '~/'
# startdate <- '1997-01-01'
# enddate <-  '1997-01-01'
# interactively <- TRUE
if (exists('database')) {
  u <- database
} else {
  u <- 'ewedb'
}
if (exists('spatialzones')) {
  s <- spatialzones
} else {
  s <- 'SD'
}
if (exists('outdir')) {
  o <- outdir
} else {
  o <- '~/'
}
if (exists('startdate')){
  startdate <- as.Date(startdate)
} else {
  startdate <- '1995-01-01'
}
if (exists('enddate')){
  enddate <- as.Date(enddate)
} else {
  enddate <-  '1995-01-01'
}
if (exists('interactively')){
  interactively <- interactively
} else {
  interactively <- FALSE
}

# this is deprecated as impairs reproducibility
if(interactively == TRUE){
  scope <- function(databaseOrBlank=u,
                    spatialzonesOrBlank = s,
                    outdirOrBlank=o,
                    startdateOrBlank=startdate,
                    enddateOrBlank=enddate){
    L <- list(
      u <- databaseOrBlank,
      s <- spatialzonesOrBlank,
      o <- outdirOrBlank,
      startdate <- startdateOrBlank,
      enddate <- enddateOrBlank
    )
    return(L)
  }
  Listed <- guiv(scope)
  Listed
  u <- Listed[1]
  s <- Listed[2]
  o <- Listed[[3]][1]
  startdate <- as.Date(Listed[[4]][1])
  enddate <- as.Date(Listed[[5]][1])
}

# this is the start of the real code
ch <- connect2postgres2(u)

# dat <- dbGetQuery(ch,
#                  "SELECT date, year, sla_code, minave, maxave, solarave, vprph09,vprph15
#                  FROM weather_sla.weather_sla
#                  where sla_code = 105051100 order by date
# ")
# with(dat, plot(date, maxave, type = 'l'))

if(s == 'SD'){
  sqlquery <- 'substr(cast(sla_code as text), 1, 3)'
} else if(s == 'SSD'){
  sqlquery <- 'substr(cast(sla_code as text), 1, 5)'
} else {
  sqlquery <- 'sla_code'
}
dat <- dbGetQuery(ch,
                  #  cat(
                  paste("
                        SELECT ",sqlquery," as ",s,", date, avg(minave) as Tmin,
                        avg(maxave) as Tmax,
                        avg(solarave) as solar,
                        avg(vprph09) as vapourpressure09,
                        avg(vprph15) as vapourpressure15
                        FROM weather_sla.weather_sla
                        where (cast(sla_code as text) not like '%99990099' and cast(sla_code as text) not like '%99999499' and cast(sla_code as text) not like '%99999899')
                        and (year between ",format(startdate, '%Y')," and ",format(enddate, '%Y'),")
                        and (date between '",startdate,"' and '",enddate,"')
                        group by date, year, ",sqlquery,"
                        order by ",sqlquery,", date", sep = "")
                  )
outputfile <- file.path(o, paste('weather_', s, '.csv', sep = ''))
write.csv(dat,outputfile, row.names=FALSE)

sprintf('Your data are now available at %s', outputfile)
