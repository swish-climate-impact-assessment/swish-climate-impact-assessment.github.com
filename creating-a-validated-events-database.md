---
name: 2013-06-08-creating-a-validated-events-database
layout: default
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


    dbSendUpdate(ch, 'CREATE SEQUENCE   "BUSHFIREREFERENCES_SEQ"
    MINVALUE 1 MAXVALUE 9999999999999999999999999999
    INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE')
  

- Create tables with primary keys and foreign keys

#### Code:
      dbSendUpdate(ch, 'CREATE TABLE  "BUSHFIREEVENTS" 
     (    "EVENTID" NUMBER NOT NULL ENABLE, 
          "EVENTTYPE" VARCHAR2(255), 
          "PLACE" VARCHAR2(255), 
          "MINDATE" DATE, 
          "MAXDATE" DATE, 
           CONSTRAINT "BUSHFIREEVENTS_PK" PRIMARY KEY ("EVENTID") ENABLE
     )')

    dbSendUpdate(ch, '
    CREATE TABLE  "BUSHFIREREFERENCES" 
    (    "REFID" NUMBER NOT NULL ENABLE, 
          "EVENTID" NUMBER NOT NULL ENABLE, 
          "AUTHOR" VARCHAR2(255), 
          "YEAR" VARCHAR2(255), 
          "TITLE" VARCHAR2(255), 
          "URL" VARCHAR2(255), 
          "NOTES" VARCHAR2(255), 
           CONSTRAINT "BUSHFIREREFERENCES_PK" PRIMARY KEY ("REFID") ENABLE
    )')

    dbSendUpdate(ch, '
    ALTER TABLE  "BUSHFIREREFERENCES" ADD CONSTRAINT "BUSHFIREREFERENCES_FK" FOREIGN KEY ("EVENTID")
              REFERENCES  "BUSHFIREEVENTS" ("EVENTID") ENABLE
    ')

-   create triggers

#### Code
    dbSendUpdate(ch, '
    CREATE OR REPLACE TRIGGER  "BI_BUSHFIREEVENTS" 
      before insert on "BUSHFIREEVENTS"               
      for each row  
    begin   
      if :NEW."EVENTID" is null then 
        select "EVENTS_SEQ".nextval into :NEW."EVENTID" from dual; 
      end if; 
    end;
    ')

    dbSendUpdate(ch, '
    ALTER TRIGGER  "BI_BUSHFIREEVENTS" ENABLE
    ')

  
    dbSendUpdate(ch, '
    CREATE OR REPLACE TRIGGER  "BI_BUSHFIREREFERENCES" 
      before insert on "BUSHFIREREFERENCES"               
      for each row  
    begin   
      if :NEW."REFID" is null then 
        select "REFERENCES_SEQ".nextval into :NEW."REFID" from dual; 
      end if; 
    end;
    ')
  
    dbSendUpdate(ch, '
    ALTER TRIGGER  "BI_BUSHFIREREFERENCES" ENABLE
    ')

### Now log in to the Oracle XE apex workspace

![eventdb-apex.png](/images/eventdb-apex.png)

### Navigate to the application builder

- Click on "Create"
- Select "Database" type
- Click "from scratch" then Next
- Give it a name, and ensure schema is selected to your workspace. Next
- Add a blank page, then Next
- One level of tabs, Next
- No shared components, Next
- Authentication scheme is Application Express, Next
- Select a Theme, Next
- Finally click "Create" to deploy the application

### Now start building the pages
- Hit Create page
- Choose form
- Choose "form on a table with report", Next
- Table Owner is our workspace, Table Name is "Events", (Choose from arrow type button)
- Select the "Page Number" and set it so the report will go on the blank page (page 1), Next
- Select all columns, Next
- Select edit image, Next
- Let Form page create a new page, rename to page2, Next
- make sure the primary key is the eventid, Next
- Define the source for pkey from existing sequence, select our EVENTS_SEQ from the list, Next
- Select all columns, Next
- Leave defaults on the Identify Process Options page, Next
- Finish
- Run page.
- No data found.  Create, add a dummy value.  If everything works add another value.  EVENTID should increment by one.  All good?  Click on the Application ID below to return to edits.
- create page, blank page, named as page 3, Next
- name as references, Next
- Say yes use tabs from existing set and create a new tab, Next
- select the tabset, next
- add tab label, Next, Finish.
- Go to top level of application, Create Page
- Form, Form on table with report
- Table owner is our workspace
- table is our references table, Next
- set it to put the report on to page 3, Next
- select all columns, Next
- edit image, Next
- create form on page 4 (this will be created), check pkey is refid, Next
- select existing sequence, it is the REFS_SEQ, Next
- select all columns, Next
- Identify Process Options are all defaults, next
- Finish and go to main application page

### Now we need to set up the link between events and related references
- Create a hidden item on report page (page3) IE P3_EVENTID, Next
- leave default, next
- leave default, create item
- Change report regions source SQL to 'WHERE EVENTID = :P3_EVENTID', apply changes
- Set up the link on page1, go to report, report attributes, edit eventID, link, Use the buttons to set as shown in the image below then Apply changes

![eventdb-link.png](/images/eventdb-link.png)


- In the References form page (page4) set the default value for say EVENTID to PL/SQL expression & = :P3_EVENTID, Apply changes
- Run the application

### TODO

- save the application to a file.
- modify the notes to a BLOB and make it a large editable window
- make the type of event a static list with dropdown menu

## References
Johnston, F., Hanigan, I., Henderson, S., Morgan, G., Portner, T., Williamson, G., and Bowman, D. (2011). Creating an integrated historical record of extreme particulate air pollution events in Australian cities from 1994 to 2007. Journal of the Air & Waste Management Association, 61(4), 390. doi:10.3155/1047-3289.61.4.390
