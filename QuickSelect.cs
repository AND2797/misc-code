using System;
using System.Collections.Generic;

class QuickSelect
{

    static void Main(string[] args)
    {

        QuickSelect qs = new QuickSelect();
        List<int> PnL = new List<int>();
        int PnLength = 20;
        Random rnd = new Random();
        for (int i = 0; i < PnLength; i++)
        {
            PnL.Add(rnd.Next(-200, 200));
        }

        for (int i = 0; i < PnL.Count; i++)
        {
            int NumberIndex = qs.Select(ref PnL, i, 0, PnL.Count - 1);
            Console.WriteLine(NumberIndex);
        }
        Console.ReadLine();
    }
    public void Swap(ref List<int> PnL, int index1, int index2)
    {
        int temp = PnL[index1];
        PnL[index1] = PnL[index2];
        PnL[index2] = temp;
    }
    public int Partition(ref List<int> PnL, int left, int right, int pivotIndex)
    {
        int PivotValue = PnL[pivotIndex];
        Swap(ref PnL, pivotIndex, right);
        int storeIndex = left;
        for (int i = left; i < right; i++)
        {
            if (PnL[i] > PivotValue)
            {
                Swap(ref PnL, i, storeIndex);
                storeIndex++;
            }
        }
        Swap(ref PnL, storeIndex, right);
        return storeIndex;
    }

    public int Select(ref List<int> PnL, int k, int left, int right)
    {
        if (left == right)
        {
            return PnL[left];
        }
        Random rnd = new Random();

        int PivotIndex = rnd.Next(left, right);
        PivotIndex = Partition(ref PnL, left, right, PivotIndex);
        if (k == PivotIndex)
        {
            return PnL[k];
        }

        if (k < PivotIndex)
        {
            return Select(ref PnL, k, left, PivotIndex - 1);
        } else {
            return Select(ref PnL, k, PivotIndex + 1, right);
        } 
    }
    
}
