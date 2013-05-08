---
layout: default
title: extractor Kepler Workflow
---

## extractor example workflow
This workflow extracts AWAP weather data for a location (or optionally for several locations).
Please see [this tutorial](http://swish-climate-impact-assessment.github.io/2013/05/extract-awap-data-4-locations/) for details and screen shots.

### Download
* This workflow [ExtractAWAPdata4locations-SETUP.kar](/tools/ExtractAWAPdata4locations/ExtractAWAPdata4locations-SETUP.kar) will attempt to set up your local R environment.
* The main workflow is [ExtractAWAPdata4locations.kar](/tools/ExtractAWAPdata4locations/ExtractAWAPdata4locations.kar)
* A test INPUT dataset is [zones.xlsx](/tools/ExtractAWAPdata4locations/zones.xlsx)
* The intended OUTPUT dataset is [Kaleen.csv](/tools/ExtractAWAPdata4locations/Kaleen.csv)
* A test [R script for debugging](/tools/ExtractAWAPdata4locations/ExtractAWAPdata4locations.r)


### Notes
* Depends on R Packages:   swishdbtools, gisviz, awaptools, reshape
* Current Version:  1.0
* Date: 	2013-05-06
* License: 	GPL2
* Author: ivanhanigan
* Maintainer: Who to complain to <ivan.hanigan@gmail.com>

