SWISH Kepler Actors Installer - Details
========================================================

## Details
This is the SWISH Kepler Actors installer, you will need Kepler and Java if you don’t have them already.
* https://kepler-project.org/users/downloads
* http://java.com/en/download/index.jsp

R is recommended for Kepler in general and required for some SWISH Climate Impact Assessment workflows.  It is important to make sure R is on your PATH Environment Variable.

The installer should work regardless of the order you install things, if you get into trouble let us know.
* [Click here for downloads](/tools/swishkepleractorsinstaller/swishkepleractorsinstaller-downloads.html)

The actors included are:
* AppendTables
* MergeTables
* SaveTable
* SelectColumnsFromTable
* SelectFromTable
* SortTable
* StataCommand
* TransposeTable
* VariableCount
* VariableIQR
* VariableMaximum
* VariableMean
* VariableMedian
* VariableMinimum
* VariableStandardDeviation
* VariableSum

 

## To use:

The easiest way to use Kepler is with the components panel that appears on the left side of the screen. You can search for actors, and drag and drop them on to the main canvas. Eg searching for 'table' or 'variable' will return most of the SWISH actors.

Each SWISH actor has one or more input connectors, an output connector, a variable(s) connector as needed, and a result connector.

The inputs and outputs need to be attached to a file name, the inputs can also be connected to the result of a previous SWISH actor.

File names are entered using the 'String Constant' actor, to set its value double click on the actors icon and edit the 'value:' parameter, click the 'Commit' button to save the value.

The variable connector identifies the table columns the actor operates on, eg the variables used to merge two tables together. Variables are also entered using a 'String Constant' actor, with multiple variable names separated by a space.

To display some text output use the 'Display' actor, note that the result output of the swish actors will just display a file name.

Finally every workflow needs one  'SDF Director' located somewhere on the main canvas. You will need to double click on the 'SDF Director' icon and set the 'iterations:' parameter to 1.

 
