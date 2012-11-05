using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Swish
{
	class TestsMain
	{
		static void Main(string[] arguments)
		{




			/// the actors are 
			/// 
			/// sort data table
			///		there is an "Array Sort" actor in kepler, works on 1d string arrays
			/// convert data - statTransfer
			/// Merge data sets
			///		there is a concatanate in kepler that takes arrays, though I don't know if it will work on tables with different type columns
			/// Append data 
			/// subset data rows and or columns
			/// Collapse rows
			/// 


			/// Input / output 
			/// 
			/// The idea is that the data source is dynamicly resloved and can be:
			///		local data file
			///		files on network server
			///		post gis database
			///		web service of some kind
			/// 
			/// 
			/// I will use strings for the data source, and test what it contains
			/// 
			/// Data output
			/// The default for an output will be the same form as the input
			/// most actors will have one output?
			/// the out put destination will be dynamically resloved similar to the inputs 
			///		may be local file
			///		network file
			///		data base?
			/// 
			/// These steps need to generate metadata 
			/// start with a log file that accopanyies the output file with the operation name and input details
			/// 
			/// 
			/// 

			/// 
			/// I believe I can link these with kepler using the cmd line executable mechnisum
			/// where necessary I will intergrate more tightly with kepler later
			/// Untimatly code written here can be eported to java, later as necessary
			/// 
			/// 
			/// 
			/// 
			/// one glaring question is how am I going to do the data operations, 
			/// options
			/// Stata
			/// r
			/// custom
			/// other
			/// 
			/// ------------------------------------
			/// Stata
			/// ------------------------------------
			/// - licance
			/// + Keith
			/// - not sure how, sounds similar, look at rundo.exe and rundolines.exe
			/// waiting to update
			/// could not find either rundo.exe or rundolines.exe
			/// 
			/// rundo.exe or rundolines.exe are seperate executables that can be downloaded from http://huebler.blogspot.com.au/2008/04/stata.html
			/// Run rundo.exe do_file_name
			/// to set these up a needed to edit the configuration file
			/// I needed to set the executable path,
			/// I needed to set the Stata window title name
			/// 
			/// Now all I need to do is:
			/// figure out the commands in Stata
			/// Figure out how to get input into Stata
			/// Figure out how to get output from Stata
			/// 
			/// to read file
			/// if the file is a *.csv to load is Stata
			/// insheet using "file name"
			/// can also use for *.dta
			/// 
			/// to save file
			/// *.csv
			/// outsheet [varlist] using "filename", comma
			/// comma - save comma seperated, default tab
			/// 
			/// sort 
			/// sort varlist, stable
			/// varlist is a list of variable names with blanks inbetween
			/// stable - values the same stay in the same order found
			/// 
			/// 
			/// 
			/// 
			/// ------------------------------------
			/// r
			/// ------------------------------------
			/// + free
			/// + Ivan
			/// + know it can be done
			/// - not sure how
			/// - not sure how to link with c#, seams that you run Rscript.exe - found in the r bin directory
			/// + there is an r library for .net
			/// 
			/// 
			/// 
			/// kepler
			/// the "External Execution"  actor runs a system command
			/// kepler has no definition of a table
			/// 
			/// blockages
			/// not sure how to run table operations
			/// not sure how to get data from kepler to external exe then out of exe back to kepler
			/// kepler has no definition of a table, there are some table like actors, but they use different data types
			/// 
			/// 
			/// 
			/// 
			/// so things I can do
			/// if kepler has a some way of using a string matrix, I could use that to internally shift data 
			/// I could easily enough shift 'string tables' in and out of kepler, 
			/// 
			/// what can I do about no tables in kepler
			/// can I make a table type and pass that around?
			/// can I have some conversion tool that converts different inputs to a 'usable table form'
			/// if r data frames exist could I just use that and convert from there
			/// I can keep all data on disk and just pass file name references
			/// 
			/// regardless right now I can just use file names as tables 
			/// all actors take a file name
			/// all actors output a file name
			/// 
			/// 

	
		}


	}
}
