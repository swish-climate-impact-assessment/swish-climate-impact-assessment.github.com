awaptools-package
========================================================

* Package: awaptools
* Type: Package
* Title: download and format Australian Water Availability Grids
* Version: 1.2.1
* Date: 2016-05-10
* Author: ivanhanigan, J. Guillaume, F. Markham, G. Williamson, I. Szarka, Jeffrey O. Hanson
* Maintainer: <ivan.hanigan@gmail.com>
* Depends: raster, sp
* Description: swish-climate-impact-assessment 
* License: GPL (>= 2)

## For developers and users
* The github repo [https://github.com/swish-climate-impact-assessment/awaptools](https://github.com/swish-climate-impact-assessment/awaptools)
* The data are described [here](/metadata/AWAP_GRIDS.html)
* R package to download and format raw gridded AWAP data and send to EWEDB (or other PostGIS server) - [awaptools](/tools/awaptools/awaptools-downloads.html)
* [Here is a workflow for extracting the data from the EWEDB](/tools/ExtractAWAPdata4locations/extract-awap.html)
* Please see [this tutorial](http://swish-climate-impact-assessment.github.io/2013/05/extract-awap-data-4-locations/) for details and screen shots.

## Downloads
### Linux 
* Use devtools::install_github("swish-climate-impact-assessment/awaptools")

### Windows
* [awaptools_1.2.zip](/tools/awaptools/awaptools_1.2.zip) Removed links to RODBC and databases like PostGIS
* [awaptools_1.1.zip](/tools/awaptools/awaptools_1.1.zip) For R 3.0 (will break on lower)
* [awaptools_1.0.zip](/tools/awaptools/awaptools_1.0.zip) For R 2.15.x
