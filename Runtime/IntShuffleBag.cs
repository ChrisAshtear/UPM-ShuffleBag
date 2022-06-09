using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntShuffleBag : ShuffleBag<int>
{
    public IntShuffleBag()
    {
    }

    public void addRange(int startVal, int endVal)
    {
        for (int i = startVal; i < endVal; i++)
        {
            values.Add(i);
        }
    }
}