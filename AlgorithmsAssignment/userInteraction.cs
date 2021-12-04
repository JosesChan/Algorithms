
using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public class userInteraction
{
    public static string[] filesAvailable(string fileLocation)
    {
        string[] validFiles = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\" + fileLocation, "*.txt");

        for (int i = 0; i < validFiles.Length; i++)
        {
            validFiles[i] = Path.GetFileNameWithoutExtension(validFiles[i]);
        }
        return (validFiles);
    }

    public static string validFileInput(string[] validInputs)
    {
        while (true)
        {
            string userInput = Console.ReadLine();

            for (int i = 0; i < validInputs.Length; i++)
            {
                if (userInput.Equals(validInputs[i], StringComparison.InvariantCultureIgnoreCase))
                {
                    return (userInput);
                }
            }
            Console.WriteLine("You're input couldn't be matched with a listed file");
            Console.WriteLine("Please input a valid file name");
        }
    }

    public static int[] fileToArray(string fileName)
    {

        List<int> integerList = new List<int>(); // list to store all the ints in the file
        int currentLineData; // stores the line's current data
        string lineData; // string var to store lines in the file
        bool validData = false; // checks if the line can be made into an int

        try
        {
            // create an instance of the stream reader class inorder to read from
            // the user's inputted file, the statement 'using' closes the streamreader
            using (StreamReader fileReader = new StreamReader(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\netfiles" + @"\" + fileName + ".txt"))
            {
                
                while ((lineData = fileReader.ReadLine()) != null)
                {
                    validData = false;
                    validData = Int32.TryParse(lineData, out currentLineData);

                    if (validData)
                    {
                        integerList.Add(currentLineData);
                    }
                    else
                    {
                        Console.WriteLine("Data couldn't be processed, please check the file for this line" + lineData);
                        Console.WriteLine("The program will continue to run without the missing line");
                    }
                }
            }
        }

        catch (Exception E)
        {
            Console.WriteLine("Error while reading file");
            Console.WriteLine("Caught an exception: " + E.Message);
        }

        return (integerList.ToArray());

    }

    public static int searchInputPrompt()
    {
        int userInput;
        bool inputOutcome = false;

        while (true)
        {
            Console.WriteLine("Please input a number to search for in the data");

            inputOutcome = Int32.TryParse(Console.ReadLine(), out userInput);

            if (inputOutcome == true)
            {
                return (userInput);
            }

            Console.WriteLine("Please enter only integers");
        }
    }

    public static bool orderInput()
    {
        while (true)
        {
            Console.WriteLine("Please input Ascending or Descending for the data to be organized in");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "ascending")
            {
                return (true);
            }
            else if (userInput.ToLower() == "descending")
            {
                return (false);
            }

            Console.WriteLine("You're input couldn't be matched with a choice");
        }
    }

    public static bool exitChoice()
    {
        while (true)
        {
            Console.WriteLine("Do you wish to exit the program? Type Yes or No");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "yes")
            {
                    Environment.Exit(0);
            }
            else if (userInput.ToLower() == "no")
            {
                return (false);
            }

            Console.WriteLine("You're input couldn't be matched with a choice");
        }
    }

    public static void outputArray(int[] inputtedArray)
    {
        Console.WriteLine("Below is every 10th/50th value:");
        for (int i = 0; i < inputtedArray.Length; i++)
        {
            if (inputtedArray.Length > 1000)
            {
                if (i % 50 == 0)
                {
                    Console.WriteLine(inputtedArray[i]);
                }
            }
            else
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(inputtedArray[i]);
                }
            }
        }
    }

    public static void outputArrayState(int[] inputtedArray, int outputChoice)
    {

        if(outputChoice == 1)
        {
            Console.WriteLine("Current Array state: ");
            for (int i = 0; i < inputtedArray.Length; i++)
            {
                Console.Write(inputtedArray[i]);
                Console.Write(" ");
            }
        }

        if (outputChoice == 0)
        {
            Console.WriteLine("Current Array state: ");
            for (int i = 0; i < inputtedArray.Length; i++)
            {
                if (inputtedArray.Length > 1000)
                {
                    if (i % 50 == 0)
                    {
                        Console.Write(inputtedArray[i]);
                        Console.Write(" ");
                    }
                }
                else
                {
                    if (i % 10 == 0)
                    {
                        Console.Write(inputtedArray[i]);
                        Console.Write(" ");
                    }
                }
            }
        }
    }

}
