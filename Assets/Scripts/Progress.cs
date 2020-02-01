﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress
{
    private float curValue = 0;
    private int minValue = 0;
    private int maxValue = 100;

    public float AddValue
    {
        get
        {
            return curValue;
        }
        set
        {
            var t = curValue + value;

            if (t > minValue)
                return;

            if (t > maxValue)
            {
                curValue = maxValue;
            }
            else 
            {
                curValue = t;
            }

            Defines.GameManager.OnProgressChange(this, t);

        }
    }
}