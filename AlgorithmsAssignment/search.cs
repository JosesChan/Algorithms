using System;
using System.Collections.Generic;
using System.Linq;

public class search
{
    // class variable
    private static List<int> locationList = new List<int>(); // list to store the locations (if multiple) of the inputted number
    private static int comparisonCounter = 0;

    // linear search
    private static void linearSearch(int targetValue, int[] inputtedArray)
    {
        for (int i = 0; i <= inputtedArray.Length-1; i++)
        {
            comparisonCounter++;
            if (inputtedArray[i] == targetValue)
            {
                locationList.Add(i);
            }
        }
    }

    // sorted data searches
    private static int binarySearchFirst(int[] inputtedArray, int min, int max, int targetValue)
    {
        if (max >= min)
        {
            int mid = ((max - min) / 2) + min; // the middle is equal to the max / 2

            comparisonCounter++;
            // if the mid point is larger than the inputted value then initiate recursion
            // analyzing the left half of the array
            if (targetValue < inputtedArray[mid])
            {
                return binarySearchFirst(inputtedArray, min, mid - 1, targetValue);
            }

            comparisonCounter++;
            // if the mid point is smaller than the inputted value then initiate recursion
            // analyzing the right half of the array
            if (targetValue > inputtedArray[mid])
            {
                return binarySearchFirst(inputtedArray, mid + 1, max, targetValue);
            }

            comparisonCounter++;
            // if the mid point is the same as the input value and it is the first occurence of its value then return mid
            if (mid == 0 || (inputtedArray[mid] == targetValue && (targetValue > inputtedArray[mid - 1])))
            {
                return mid;
            }

            comparisonCounter++;
            // if it matches the target value then intiate recursion for left half
            if (inputtedArray[mid] == targetValue)
            {
                return binarySearchFirst(inputtedArray, min, mid - 1, targetValue);
            }
        }
        // return -1 if the location can't be found
        return (-1);
    }

    private static int binarySearchLast(int[] inputtedArray, int min, int max, int targetValue)
    {
        if (max >= min)
        {
            int mid = ((max - min) / 2) + min; // the middle is equal to the max / 2
            
            comparisonCounter++;
            // if the mid point is larger than the inputted value then initiate recursion
            // analyzing the left half of the array
            if (targetValue < inputtedArray[mid])
            {
                return binarySearchLast(inputtedArray, min, mid - 1, targetValue);
            }

            comparisonCounter++;
            // if the mid point is smaller than the inputted value then initiate recursion
            // analyzing the right half of the array
            if (targetValue > inputtedArray[mid])
            {
                return binarySearchLast(inputtedArray, mid + 1, max, targetValue);
            }

            comparisonCounter++;
            // if the mid point is at the last element or if it is the inputted value and the next value is larger
            // return mid
            if (mid == inputtedArray.Length - 1 || (inputtedArray[mid] == targetValue && (targetValue < inputtedArray[mid + 1])))
            {
                return mid;
            }

            comparisonCounter++;
            // if it matches the target value then intiate recursion for right half
            if (inputtedArray[mid] == targetValue)
            {
                return binarySearchLast(inputtedArray, mid + 1, max, targetValue);
            }
        }
        // return -1 if the location can't be found
        return (-1);
    }

    // adds all occurence locations of the value to a list
    private static void binarySearchRange(int inputtedValue, int[] inputtedArray)
    {
        int firstOccurrence = 0;
        int lastOccurrence = 0;

        // stores first and last occurence of the target number
        firstOccurrence = binarySearchFirst(inputtedArray, 0, inputtedArray.Length - 1, inputtedValue);
        lastOccurrence = binarySearchLast(inputtedArray, 0, inputtedArray.Length - 1, inputtedValue);

        while (firstOccurrence <= lastOccurrence)
        {
            locationList.Add(firstOccurrence);
            firstOccurrence++;
        }
    }

    // functions add to and print the list
    public static void searchForValue(int inputtedValue, int[] inputtedArray, bool ascendingOrder)
    {

        if (ascendingOrder == false)
        {
            Console.WriteLine("Using linear search:");
            linearSearch(inputtedValue, inputtedArray);
        }
        else
        {
            Console.WriteLine("Using binary search:");
            binarySearchRange(inputtedValue, inputtedArray);
        }

        printLocationsList();
    }

    private static void printLocationsList()
    {
        if (!locationList.Any() || locationList[0] == -1)
        {
            Console.WriteLine("We couldn't find the value you inputted");
        }
        else
        {

            Console.WriteLine("The value have been found at location(s): ");
            for (int i = 0; i < locationList.Count; i++)
            {
                Console.WriteLine(locationList[i] + " ");
            }

            Console.WriteLine("The program used " + comparisonCounter + " comparisons to search");
        }
        comparisonCounter = 0; // reset counter
        locationList.Clear(); // clear for next use
    }

    /*
	// unsorted data searches
	private static int linearSearchNearestNumber(int targetValue, int[] inputArray)
	{
		int smallestLocation = 0; // in reference to target number
		int largestLocation = 0; // in reference to target number
		double smallDif = 0;
		double largeDif = 0;
		for (int i = 0; i < inputArray.Length; i++)
		{
			if (smallestLocation > inputArray[i])
			{
				smallestLocation = inputArray[i];
			}
			if (largestLocation < inputArray[i])
			{
				largestLocation = inputArray[i];
			}
		}

		smallDif = targetValue - inputArray[smallestLocation];
		largeDif = inputArray[largestLocation] - Int32.Parse(targetValue);
		if (smallDif >= largeDif)
		{
			return (inputArray[smallestLocation]);
		} 
		else
		{
			return (inputArray[largestLocation]);
		}

		return (-1);
	}
	
	public static void searchForValueNearest(int inputtedValue, int[] inputtedArray)
	{
		linearSearchNearestNumber(inputtedValue, inputtedArray);
		printLocationsList();
	}
	*/
}
