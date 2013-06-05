
source(file.path(workdir,'connect.r'))
if(s == 'SD'){
  sqlquery <- 'substr(cast(t1.sla_code as text), 1, 3)'
} else if(s == 'SSD'){
  sqlquery <- 'substr(cast(t1.sla_code as text), 1, 5)'
} else {
  sqlquery <- 't1.sla_code'
}
dat <- dbGetQuery(ch,
#                  cat(
                  paste("
                        SELECT ",sqlquery," as ",s,",
                        sum(t2.pop_2001) as totalpers, date,
                        sum(minave * pop_2001)/sum(pop_2001) as Tmin,
                        sum(maxave * pop_2001)/sum(pop_2001) as Tmax,
                        sum(solarave * pop_2001)/sum(pop_2001) as solar,
                        sum(vprph09 * pop_2001)/sum(pop_2001) as vapourpressure09,
                        sum(vprph15 * pop_2001)/sum(pop_2001) as vapourpressure15
                        FROM weather_sla.weather_sla t1
                         join abs_sla_erp.austsla_erp_01 t2
                         on t1.sla_code = t2.sla_code
                        where agesex = 'TotalTotal'
                        and (cast(t1.sla_code as text) not like '%99990099'
                         and cast(t1.sla_code as text) not like '%99999499'
                         and cast(t1.sla_code as text) not like '%99999899')
                        and (cast(t1.sla_code as text) not in ('910052009','910053009'))
                        and (year between ",format(as.Date(startdate), '%Y'),"
                         and ",format(as.Date(enddate), '%Y'),")
                        and (date between '",startdate,"' and '",enddate,"')
                        GROUP BY date, year, ",sqlquery,"
                        having sum(pop_2001) > 0
                        order by ",sqlquery,", date
                        ", sep = "")
                    )

outputfile <- file.path(o, paste('weather_', s, '.csv', sep = ''))
write.csv(dat,outputfile, row.names=FALSE)

sprintf('Your data are now available at %s', outputfile)
