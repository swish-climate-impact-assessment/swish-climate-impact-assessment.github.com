SWISH Kepler Actors Installer - Details
========================================================

## Details
This is the SWISH Kepler Actors installer, you will need Kepler and Java if you don’t have them already.
* https://kepler-project.org/users/downloads
* http://java.com/en/download/index.jsp

R is recommended for Kepler in general and required for some SWISH Climate Impact Assessment workflows.  It is important to make sure R is on your PATH Environment Variable.

### The installer 

should work regardless of the order you install things, if you get into trouble let us know.
* [Click here for downloads](/tools/swishkepleractorsinstaller/swishkepleractorsinstaller-downloads.html)

To use SWISH Kepler Actors, Kepler 2.3, Java JRE or JDK, Stata 12, and Microsoft .Net framework 4 are required. The installer is built to work on Microsoft Windows systems, and will not work correctly on Linux systems. The installer will need to be run for each user that wishes to user SWISH Kepler actors.

Kepler: https://kepler-project.org/

Java 6: http://www.oracle.com/technetwork/java/javase/readme-142177.html

Microsoft .net framework 4 is available on Windows 7, but will need to be additionally installed for Windows Vista or XP. It is available at http://www.microsoft.com/en-us/download/details.aspx?id=17851

Stata 12: http://www.stata.com/stata12/

The installer can be run directly and provided with arguments. The installer is called “Swish.SimpleInstaller.exe” and located in the installer bin folder. To run the graphical user interface (GUI) normally provide no arguments, to uninstall use the “/clean” argument. To install or uninstall automatically with no user interface add the “/silient” argument. To display extra information during the process add the “/verbose” argument, this can help find errors if the process fails.

You can run the installer directly using the command prompt. Enter “Swish.SimpleInstaller.exe” and then any arguments separated by spaces.

EG: if the installer in on the desktop

> C:\Users\Ian\Desktop\SwishInstaller\Swish.SimpleInstaller.exe   /clean   /silent

[Note you can open the command prompt by pressing WindowsKey + R and enter “cmd”]

 

The installer copies actor files to where they will be automatically loaded by Kepler and copies executable files to where they are used by the actors. The Actor files are copied to the directory “C:\Users\%UserName%\KeplerData\workflows\MyWorkflows”, where %UserName% is the name of the user profile logged on during installation. Executable files are copied to the “C:\Swish\bin” directory. The files copied during installation can all be found under the installer “%Installer%\bin” folder. Files in the “%Installer%\bin\Actors” are copied to the “C:\Users \....\MyWorkflows”, and files in “%Installer%\bin\SwishBin” are copied to “C:\Swish\bin”.

The installer follows instructions found in install.txt. This file can be edited as new files are added to the install. The “CopyFiles” “Source directory” “Destination directory” command copies all the contents of a directory. The “Copy” “Source file” “Destination file” command copies a single file to a location. File paths can be constructed using “%StartupPath%” for the location of the installer, and “%UserProfile%” for the location of the logged on user profile directory.


### The Actors
Most of the SWISH actors require a data input as well as some parameters and produce a data output. A data input can be a file path to a Stata “.dta” file or a “.csv” file. The output will be a file name to a “.dta” file located in the temporary directory. Other actor parameters can be added easily using string constants.

To save the result of a SWISH actor connect its output to a SaveTable actor, it can be saved as a Stata “.dta” file or a “.csv” file. Intermediate results between actors do not need to be saved explicitly as SWISH actors are designed to be linked together. The output of one SWISH actor can just be linked directly to the input of the next SWISH actor.

Variable names are the columns names in data sets. When a SWISH actor input is a variable name and it makes sense to do so, multiple variable names can be specified, separated by spaces. Eg the SortTable actor.

The actors are AppendTables, CompressTable, DisplayTable, EncodeArgument, FormatVariables, GenerateVariable, GetFileName, GetFileNameWithoutExtension, MergeTables, Password, RemoveColumns, ReplaceValues, RunDoScript, SaveTable, SelectColumns, SelectRecords, SortTable, StataCommand, TransposeTable, VariableCount, VariableIQR, VariableMaximum, VariableMean, VariableMedian, VariableMinimum, VariableStandardDeviation, and VariableSum.

### To use these actors:

The easiest way to use Kepler is with the components panel that appears on the left side of the screen. You can search for actors, and drag and drop them on to the main canvas. Eg searching for 'table' or 'variable' will return most of the SWISH actors.

Each SWISH actor has one or more input connectors, an output connector, a variable(s) connector as needed, and a result connector.

The inputs and outputs need to be attached to a file name, the inputs can also be connected to the result of a previous SWISH actor.

File names are entered using the 'String Constant' actor, to set its value double click on the actors icon and edit the 'value:' parameter, click the 'Commit' button to save the value.

The variable connector identifies the table columns the actor operates on, eg the variables used to merge two tables together. Variables are also entered using a 'String Constant' actor, with multiple variable names separated by a space.

To display some text output use the 'Display' actor, note that the result output of the swish actors will just display a file name.

Finally every workflow needs one  'SDF Director' located somewhere on the main canvas. You will need to double click on the 'SDF Director' icon and set the 'iterations:' parameter to 1.

 
