using System;

public class sort
{
    private static int swapCounter = 0;
    private static int comparisonCounter = 0;
    private static int outputFull = -1;

    private static void swapIntValues(ref int valueOne, ref int valueTwo)
    {
        swapCounter++;
        int valueStorage = valueOne;
        valueOne = valueTwo;
        valueTwo = valueStorage;
    }

    private static void introSortAscending(ref int[] targetArray)
    {
        // inputs array data into partition function to get a partition index
        // in order to dictate which sort is to be used on the array
        int partitionSize = Partition(ref targetArray, 0, targetArray.Length - 1);

        // if the partition size is less than 16 it is optimal to use insertion
        // else check if its optimal to use heap sort
        // if not then use quick sort
        if (partitionSize < 16)
        {
            insertionSort(ref targetArray);
        }
        else if (partitionSize > (2 * Math.Log(targetArray.Length)))
        {
            heapSortAscending(ref targetArray);
        }

        else
        {
            quickSortAscending(ref targetArray, 0, targetArray.Length - 1);
        }

    }

    private static void introSortDescending(ref int[] targetArray)
    {
        // inputs array data into partition function to get a partition index
        // in order to dictate which sort is to be used on the array
        int partitionSize = Partition(ref targetArray, 0, targetArray.Length - 1);

        // if the partition size is less than 16 it is optimal to use insertion
        // else check if its optimal to use heap sort
        // if not then use quick sort
        if (partitionSize < 16)
        {
            insertionReverseSort(ref targetArray);
        }
        else if (partitionSize > (2 * Math.Log(targetArray.Length)))
        {
            heapSortDescending(ref targetArray);
        }
        else
        {
            quickSortDescending(ref targetArray, 0, targetArray.Length - 1);
        }
    }

    private static void insertionSort(ref int[] targetArray)
    {
        for (int i = 1; i < targetArray.Length; ++i)
        {
            // key holds the current location for comparison 
            int key = targetArray[i];
            int j = i - 1;
            comparisonCounter++;
            // shift all the values that are greater than the key to the next position
            while (j >= 0 && targetArray[j] > key)
            {
                targetArray[j + 1] = targetArray[j];
                j--;
                swapCounter++; // note this counts all the shifts of elements
            }
            // the key has found its place in the array, set the location as key
            targetArray[j + 1] = key;
            userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
        }
    }

    private static void insertionReverseSort(ref int[] targetArray)
    {
        for (int i = 1; i < targetArray.Length; ++i)
        {

            // key holds the current location for comparison when shifting values
            int key = targetArray[i];
            int j = i - 1;
            comparisonCounter++;
            // shift all the values that are lesser than the key to the next position
            while (j >= 0 && targetArray[j] < key)
            {
                swapCounter++; // note this counts all the shifts of elements
                swapIntValues(ref targetArray[j + 1], ref targetArray[j]);
                j--;
            }
            // the key has found its place in the array, set the location as key
            targetArray[j + 1] = key;
            userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
        }
    }

    private static void heapSortAscending(ref int[] targetArray)
    {
        int heapSize = targetArray.Length;

        for (int p = (heapSize - 1) / 2; p >= 0; --p)
        {
            maxHeapify(ref targetArray, heapSize, p);
        }

        for (int i = targetArray.Length - 1; i > 0; --i)
        {
            swapCounter++;
            swapIntValues(ref targetArray[i], ref targetArray[0]);
            userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
            --heapSize;
            maxHeapify(ref targetArray, heapSize, 0);
        }
    }

    private static void heapSortDescending(ref int[] targetArray)
    {
        int heapSize = targetArray.Length;

        for (int p = (heapSize - 1) / 2; p >= 0; --p)
        {
            minHeapify(ref targetArray, heapSize, p);
        }
        for (int i = targetArray.Length - 1; i > 0; --i)
        {
            swapCounter++;
            swapIntValues(ref targetArray[i], ref targetArray[0]);
            userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
            --heapSize;
            minHeapify(ref targetArray, heapSize, 0);
        }
    }

    private static void maxHeapify(ref int[] targetArray, int heapSize, int index)
    {
        // max heapify goes through the data structure and ensures it keeps/creates 
        // the max heap property, where values cannot exceed the values of its parents

        int left = (index + 1) * 2 - 1;
        int right = (index + 1) * 2;
        int largest = index;

        // if left is bigger than the root, make largest the left child
        comparisonCounter++;
        if (left < heapSize && targetArray[left] > targetArray[index])
        {
            largest = left;
        }

        // if right is bigger than the root, make largest the right child
        comparisonCounter++;
        if (right < heapSize && targetArray[right] > targetArray[largest])
        {
            largest = right;
        }

        // continue heapifying through recursion
        if (largest != index)
        {
            swapCounter++;
            swapIntValues(ref targetArray[index], ref targetArray[largest]);
            userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
            maxHeapify(ref targetArray, heapSize, largest);
        }
    }

    private static void minHeapify(ref int[] targetArray, int heapSize, int index)
    {
        // min heapify goes through the data structure and ensures it keeps/creates 
        // the min heap property, where values cannot bne below the values of its parents



        int left = (index + 1) * 2 - 1;
        int right = (index + 1) * 2;
        int smallest = index;

        // if left is bigger than the root, make smallest the left child
        comparisonCounter++;
        if (left < heapSize && targetArray[left] < targetArray[index])
            smallest = left;

        // if right is bigger than the root, make smallest the right child
        comparisonCounter++;
        if (right < heapSize && targetArray[right] < targetArray[smallest])
            smallest = right;

        // continue heapifying through recursion
        if (smallest != index)
        {
            comparisonCounter++;
            swapIntValues(ref targetArray[index], ref targetArray[smallest]);
            userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
            minHeapify(ref targetArray, heapSize, smallest);
        }
    }

    private static void quickSortAscending(ref int[] targetArray, int leftPivot, int rightPivot)
    {
        if (leftPivot < rightPivot)
        {
            int partitionSize = Partition(ref targetArray, leftPivot, rightPivot);

            quickSortAscending(ref targetArray, leftPivot, partitionSize - 1);
            quickSortAscending(ref targetArray, partitionSize + 1, rightPivot);
        }
    }

    private static void quickSortDescending(ref int[] targetArray, int leftPivot, int rightPivot)
    {
        if (leftPivot < rightPivot)
        {
            int partitionSize = PartitionDescending(ref targetArray, leftPivot, rightPivot);

            quickSortDescending(ref targetArray, leftPivot, partitionSize - 1);
            quickSortDescending(ref targetArray, partitionSize + 1, rightPivot);
        }
    }

    private static int Partition(ref int[] targetArray, int left, int right)
    {
        int pivot = targetArray[right];
        int i = left;

        // for the size of the partition, scan and swap values that are
        // smaller than the pivot leaving them left of the pivot post operation
        // and greater values on the left
        for (int j = left; j < right; ++j)
        {
            comparisonCounter++;
            if (targetArray[j] <= pivot)
            {
                swapCounter++;
                swapIntValues(ref targetArray[j], ref targetArray[i]);
                userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
                i++;
            }
        }

        swapIntValues(ref targetArray[right], ref targetArray[i]);
        return i;
    }

    private static int PartitionDescending(ref int[] targetArray, int left, int right)
    {
        int pivot = targetArray[right];
        int i = left;

        // for the size of the partition, scan and swap values that are
        // greater than the pivot leaving them left of the pivot post operation
        // and smaller values on the left
        for (int j = left; j < right; ++j)
        {
            comparisonCounter++;
            if (targetArray[j] > pivot)
            {
                swapCounter++;
                swapIntValues(ref targetArray[j], ref targetArray[i]);
                userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
                i++;
            }
        }

        swapIntValues(ref targetArray[right], ref targetArray[i]);
        return i;
    }

    private static void bubbleSortAscending(ref int[] targetArray)
    {
        int arraySize = targetArray.Length;
        bool swapStatus = false;

        for (int i = 0; i < arraySize - 1; i++)
        {
            swapStatus = false;
            for (int j = 0; j < arraySize - i - 1; j++)
            {
                comparisonCounter++;
                if (targetArray[j] > targetArray[j + 1])
                {
                    // swap positions
                    swapCounter++;
                    swapStatus = true;
                    swapIntValues(ref targetArray[j], ref targetArray[j + 1]);
                    userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
                }
            }
            // if there was no swaps made during the run, then the array is sorted
            if (swapStatus == false)
            {
                break;
            }
        }
    }

    private static void bubbleSortDescending(ref int[] targetArray)
    {
        int arraySize = targetArray.Length;
        bool swapStatus = false;

        for (int i = 0; i < arraySize - 1; i++)
        {
            swapStatus = false;
            for (int j = 0; j < arraySize - i - 1; j++)
            {
                comparisonCounter++;
                if (targetArray[j] < targetArray[j + 1])
                {
                    swapCounter++;
                    // swap positions
                    swapIntValues(ref targetArray[j], ref targetArray[j + 1]);
                    userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
                    swapStatus = true;
                }
            }
            // if there was no swaps made during the run, then the array is sorted
            if (swapStatus == false)
            {
                break;
            }
        }
    }

    private static void selectionSortAscending(ref int[] targetArray)
    {
        int arraySize = targetArray.Length;

        for (int i = 0; i < arraySize - 1; i++)
        {
            int currentLocationPointer = i;
            for (int selectedLocation = i + 1; selectedLocation < arraySize; selectedLocation++)
            {
                comparisonCounter++;
                if (targetArray[selectedLocation] < targetArray[currentLocationPointer])
                {

                    currentLocationPointer = selectedLocation;
                }
            }

            // if the value belongs where it was found then do not swap
            if (currentLocationPointer != i)
            {
                // Swap the selected array values
                swapCounter++;
                swapIntValues(ref targetArray[i], ref targetArray[currentLocationPointer]);
                userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
            }
        }
    }

    private static void selectionSortDescending(ref int[] targetArray)
    {
        int arraySize = targetArray.Length;
        for (int i = 0; i < arraySize - 1; i++)
        {
            int currentLocationPointer = i;
            for (int selectedLocation = i + 1; selectedLocation < arraySize; selectedLocation++)
            {
                comparisonCounter++;
                if (targetArray[selectedLocation] > targetArray[currentLocationPointer])
                {

                    currentLocationPointer = selectedLocation;
                }
            }

            // if the value belongs where it was found then do not swap
            if (currentLocationPointer != i)
            {
                // Swap the selected array values
                swapCounter++;
                swapIntValues(ref targetArray[i], ref targetArray[currentLocationPointer]);
                userInteraction.outputArrayState(targetArray, outputFull); // output array state after operation
            }
        }
    }

    public static bool chooseSort(ref int[] targetArray, bool sortAscend)
    {
        bool sortAccomplished = false;
        string sortChoice;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("If you wish to output the full array after each swap please, type yes (Note: Takes a while)");
            Console.WriteLine();
            Console.WriteLine("If you wish to output the every 10th/50th value of the array after each swap, type no");
            Console.WriteLine();
            Console.WriteLine("If you wish to not see the array after each swap, type hide");

            string userInput = Console.ReadLine().ToLower();
            if (userInput == "yes")
            {
                outputFull = 1;
                break;
            }
            if (userInput == "no")
            {
                outputFull = 0;
                break;
            }
            if (userInput == "hide")
            {
                outputFull = -1;
                break;
            }

            Console.WriteLine("Your input could not be matched");
            Console.WriteLine("Please input yes or no or hide");
        }


        Console.WriteLine("Please choose any of the following sorting algorithms");
        Console.WriteLine("Bubblesort");
        Console.WriteLine("Selectionsort");
        Console.WriteLine("Introsort");
        Console.WriteLine("Quicksort");

        sortChoice = Console.ReadLine();


        if (sortAscend == true)
        {
            if (sortChoice.Replace(" ", "").ToLower() == "introsort")
            {
                // perform sort
                introSortAscending(ref targetArray);
                sortAccomplished = true;

                // return info to the user of how the sort performed
                Console.WriteLine();
                Console.WriteLine("Introsort performed " + swapCounter + " swaps");
                Console.WriteLine("and " + comparisonCounter + " comparisons");

                // reset the counters
                comparisonCounter = 0;
                swapCounter = 0;

            }
            if (sortChoice.Replace(" ", "").ToLower() == "bubblesort")
            {
                // perform sort
                bubbleSortAscending(ref targetArray);
                sortAccomplished = true;

                // return info to the user of how the sort performed
                Console.WriteLine();
                Console.WriteLine("Bubblesort performed " + swapCounter + " swaps");
                Console.WriteLine("and " + comparisonCounter + " comparisons");

                // reset the counters
                comparisonCounter = 0;
                swapCounter = 0;
            }
            if (sortChoice.Replace(" ", "").ToLower() == "quicksort")
            {
                // perform sort
                quickSortAscending(ref targetArray, 0, targetArray.Length - 1);
                sortAccomplished = true;

                // return info to the user of how the sort performed
                Console.WriteLine();
                Console.WriteLine("Quicksort performed " + swapCounter + " swaps");
                Console.WriteLine("and " + comparisonCounter + " comparisons");

                // reset the counters
                comparisonCounter = 0;
                swapCounter = 0;
            }
            if (sortChoice.Replace(" ", "").ToLower() == "selectionsort")
            {
                // perform sort
                selectionSortAscending(ref targetArray);
                sortAccomplished = true;

                // return info to the user of how the sort performed
                Console.WriteLine();
                Console.WriteLine("Selectionsort performed " + swapCounter + " swaps");
                Console.WriteLine("and " + comparisonCounter + " comparisons");

                // reset the counters
                comparisonCounter = 0;
                swapCounter = 0;
            }
        }

        if (sortAscend == false)
        {
            if (sortChoice.Replace(" ", "").ToLower() == "introsort")
            {
                // perform sort
                introSortDescending(ref targetArray);
                sortAccomplished = true;

                // return info to the user of how the sort performed
                Console.WriteLine();
                Console.WriteLine("Introsort performed " + swapCounter + " swaps");
                Console.WriteLine("and " + comparisonCounter + " comparisons");

                // reset the counters
                comparisonCounter = 0;
                swapCounter = 0;
            }
            if (sortChoice.Replace(" ", "").ToLower() == "bubblesort")
            {
                // perform sort
                bubbleSortDescending(ref targetArray);
                sortAccomplished = true;

                // return info to the user of how the sort performed
                Console.WriteLine();
                Console.WriteLine("Bubblesort performed " + swapCounter + " swaps");
                Console.WriteLine("and " + comparisonCounter + " comparisons");

                // reset the counters
                comparisonCounter = 0;
                swapCounter = 0;
            }
            if (sortChoice.Replace(" ", "").ToLower() == "quicksort")
            {
                // perform sort
                quickSortDescending(ref targetArray, 0, targetArray.Length - 1);
                sortAccomplished = true;

                // return info to the user of how the sort performed
                Console.WriteLine();
                Console.WriteLine("Quicksort performed " + swapCounter + " swaps");
                Console.WriteLine("and " + comparisonCounter + " comparisons");

                // reset the counters
                comparisonCounter = 0;
                swapCounter = 0;
            }
            if (sortChoice.Replace(" ", "").ToLower() == "selectionsort")
            {
                // perform sort
                selectionSortDescending(ref targetArray);
                sortAccomplished = true;

                // return info to the user of how the sort performed
                Console.WriteLine();
                Console.WriteLine("Selectionsort performed " + swapCounter + " swaps");
                Console.WriteLine("and " + comparisonCounter + " comparisons");

                // reset the counters
                comparisonCounter = 0;
                swapCounter = 0;
            }
        }

        if (sortAccomplished == false)
        {
            Console.WriteLine("We could not determine your input, please try again");
            Console.WriteLine();
        }

        return sortAccomplished;

    }

}