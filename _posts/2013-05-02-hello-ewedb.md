---
name: hello-ewedb
layout: post
title: Hello EWEDB (Simple Set Up the Swish Computer to connect to EWEDB)
date: 2013-05-02
categories:
- simple
- set up
- connecting
---

## Hello EWEDB
This is a very simple workflow designed to install the swishdbtools R package and test the setup of your computer and the connection to the EWEDB.

### Step 1
Download [the "hello-ewedb.kar" workflow](/tools/hello-ewedb/hello-ewedb.html)

### Step 2
Run the workflow.  

![hello-ewedb-Slide1.PNG](/images/hello-ewedb/hello-ewedb-Slide1.PNG)


### Step 3
Enter the details.  When you run this it will download the R package and install it, along with its dependencies.  It will then look for your PostGIS username and password, if it can't find a valid username, password, database and server combination it will ask you to enter them.

### ON MS WINDOWS THE POPUP BOX IS OFTEN BEHIND OTHER WINDOWS.

You will have recieved a username and password when the Data Manager set up your account.

![setup-swish-Slide10.PNG](/images/setup-swish-Slide10.PNG)

![setup-swish-Slide11.PNG](/images/setup-swish-Slide11.PNG)

On MS Windows your details are now stored in this file or ~/.pgpass on Linux. 

![setup-swish-Slide12.PNG](/images/setup-swish-Slide12.PNG)
  
### Step 3
Verify the test data "hello_ewedb" was written to the database, and read back out again, and removed afterward.

![hello-ewedb-Slide2.PNG](/images/hello-ewedb/hello-ewedb-Slide2.PNG)

