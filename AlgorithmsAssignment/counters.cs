using System;

public class counters
{
    // private variables for counting
    private int swapCounter = 0;
    private int compareCounter = 0;

    // getters and setters (setter only increments)
    public int swapCount   
  {
        get { return swapCounter; }
    }

    public int comparisonCount {
        get { return compareCounter; }
    }

    public void incrementSwapCount()
    {
        swapCounter = swapCounter++;
    }

    public void incrementCompareCount() {
        compareCounter = compareCounter++;
    }
}
