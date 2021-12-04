using System;
using System.Collections.Generic;

/*
* Steps for how the program works
* 1. Select which array to analyze
* 2. Sort in ascending and descending order, display every 10th value
* 3. Search the selected array for a user-defined value, provide location of all its occurences else output an error message
* Searches in binary or linear depending on ascending/descending
*/


namespace AlgorithmsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targetArray; // array to store all the ints
            string[] fileNames; // array to store the amount different file name options
            string targetFile; // variable to store the name of the file
            bool orderChoice = true;
            
            Console.WriteLine("Step 1 - Read in file");

            // prompts user and gets stores all available file names
            Console.WriteLine("Input a file name");
            fileNames = userInteraction.filesAvailable("netFiles");

            while (true)
            {
                // print all file names
                foreach (var files in fileNames)
                {
                    Console.WriteLine(files.ToString());
                }

                // process file into array
                targetFile = userInteraction.validFileInput(fileNames);
                targetArray = userInteraction.fileToArray(targetFile);

                Console.WriteLine("Step 2 - Sort");

                // sorts the array
                orderChoice = userInteraction.orderInput(); // get ascending or descending
                while (sort.chooseSort(ref targetArray, orderChoice) == false); // sort accordingly to chosen algorithm
                

                Console.WriteLine("Type a button to read the array");
                Console.ReadKey();
                Console.WriteLine();

                // outputs array
                userInteraction.outputArray(targetArray);

                Console.WriteLine("Step 3 - Search for the value's location(s)");

                // calls functions to get a valid value to search for
                search.searchForValue(userInteraction.searchInputPrompt(), targetArray, orderChoice);

                userInteraction.exitChoice();
                
            }
        }
    }
}
