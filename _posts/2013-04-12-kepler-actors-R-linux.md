---
name: kepler-actors-R-linux
layout: default
title: Kepler Actors with R on Linux
---

The design of the SWISH Kepler actors is to take files and create files.

If data is passed between actors then temporary files are created in the temporary directory after each actor completes, and are fed to the subsequent actors.

For the R actors, on windows this is achieved using the TEMP environment variable.  On linux this might not exist.

This can be created by adding the following line to /usr/lib/R/etc/Rprofile.site 

    Sys.setenv(TEMP = "/tmp")
