---
name: 2013-06-08-creating-a-validated-events-database
layout: post
title: Creating a Validated Events Database
categories:
- validated events
---

## Creating a database for a validated historical record of events
In a previous project Ivan was involved with the creation of a database of validated extreme bushfire pollution episodes.  This involved an integration of environmental data and content analysis of historical documentation.  This post will describe the database layout and in particular the approach taken to link ('tag'?) documentary evidence to event descriptions.  

## Why do we need to link multiple lines of evidence from documentary sources?
The alternate approach to identify extreme events is to look at the distribution of the observed historical data and define an arbritrary threshold such as the 99th percentile an label any observations that achieve this threshold as 'extreme'.  This approach is limited by assumptions and data availabilty.  The use of multiple sources of information has the benefit of allowing analysts to explore the different dimensions of the events that make the considered 'extreme' by a broader spectrum of people.  For example a extreme heat event might achieve a criteria on one index say maximum daytime temperature, but not on others such as minimum night-time temperature or accumulated heat stress with no relief over several days.

## Step one: identify the key variables and summarise their historical distributions
The ultimate aim of gathering references from multiple sources is to find evidence that supports the claim that any particular 'event' identified from the observed data is indeed considered extreme but the mutli-criteria reality of the phenomenon.  So in the case of the bushfire pollution case study we needed to find out what were the extreme pollution days.  Equivalently we would summarise the historical heat records for heatwaves or dryness records for drought.

## Step two: find supporting evidence that these event locations and dates were considered extreme
In many cases government reports and news media are good sources for this.  Sometimes really extreme events might be assessed by scholars and entire reports or books might be written deconstructing the event and discussing the causal factors.

## How to keep track of all the references?
Because we aim to support each individual event with multiple source references a relational database suggests itself.  In addition because we will want to capture our 'tagged' notes and explanatory discussions that expand on why we think each piece of evidence is relevant a data entry form is suggested so humans can easily add textual and numeric information.  As this is a large exercise that will require efforts by multiple people a distruted system with a central data store is recommended such that data entry is conducted using web-forms that connect the users to the central database.  

## Database solutions
The exploration we conducted examined three databse solutions (presented in order of cost and open-ness of source code):

- Web2Py
- Oracle XE APEX
- Microsoft Access

We decided to go with Oracle XE Apex because of the lower level of expertise required to construct the web-forms.

## Setting up the Oracle XE server
See Ivan's instructions at the OpenSoftware-RestrictedData website.  Create a workspace for your projects. 

## Setting up the Web-Forms
These notes are from Ivan's explorations and serve more as a reminder of what worked rather than a description of why these steps should be conducted.  A thorough review of the Oracle XE apex tutorials will also help.


## Create Two Linked Tables using R/SQL
The database relies on two tables: one for the events and the other for the references.  Creating these using the R/SQL method will allow the process to be scripted, giving better reproducibility and also extension later, follow these steps.

- Connect R to the oracle db

#### Code
    require(swishdbtools)
    require(ddiindexdb)
    pwd <- getPassword()
    ch <- connect2oracle(hostip = 'IP.ADDRESS', db = 'WORKSPACE', p = pwd)


- Create sequences

#### Code:
    dbSendUpdate(ch, 'CREATE SEQUENCE   "BUSHFIREEVENTS_SEQ"  
    MINVALUE 1 MAXVALUE 9999999999999999999999999999 
    INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE')

- Create tables with primary keys and foreign keys

#### Code:
      dbSendUpdate(ch, 'CREATE TABLE  "BUSHFIREEVENTS" 
     (    "EVENTID" NUMBER NOT NULL ENABLE, 
          "REFID" NUMBER, 
          "EVENTTYPE" VARCHAR2(255), 
          "PLACE" VARCHAR2(255), 
          "MINDATE" DATE, 
          "MAXDATE" DATE, 
           CONSTRAINT "BUSHFIREEVENTS_PK" PRIMARY KEY ("EVENTID") ENABLE
     )')


-   create triggers

### log in to apex workspace

![eventdb-apex.png](/images/eventdb-apex.png)


-   create blank pages
-   create new page
-             choose form
-             choose form on report
-             select the report to go on the blank page
-  10)        let the form create a new page
-  11)create a hidden item on report page IE :P2_IDNO
-  12)change report regions source SQL to 'WHERE [IDNO/FILEID ETC] = :P2_IDNO
-  13)set up the link on the previous page if applicable
-  in the form page set the default value for say IDNO to PL/SQL expression & = :P2_IDNO for eg


## References
Johnston, F., Hanigan, I., Henderson, S., Morgan, G., Portner, T., Williamson, G., and Bowman, D. (2011). Creating an integrated historical record of extreme particulate air pollution events in Australian cities from 1994 to 2007. Journal of the Air & Waste Management Association, 61(4), 390. doi:10.3155/1047-3289.61.4.390
