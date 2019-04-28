using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock
{
    // add News
    List<float> values = new List<float>();
    string key;
    float dividend;
    int shares, myShares;

    public Stock(string key, float dividend, float value, int shares)
    {
        this.key = key;
        this.dividend = dividend;
        values.Add(value);
        this.shares = shares;
        myShares = 0;
    }

    public void setValue(float val)
    {
        values.Add(val);
    }

    public float getValue()
    {
        if (values.Count > 0)
        {
            return values[values.Count - 1];
        }
        return -1f;
    }

    public float getValue(int time)
    {
        if (time > 0)
        {
            return values[time];
        }
        return -1f;
    }

    public float getTrend()
    {
        if (values.Count > 1)
        {
            return values[values.Count - 1] / values[values.Count - 2];
        }
        return -1f;
    }

    public float getTrend(int time)
    {
        if (values.Count > 1)
        {
            return values[time] / values[time - 1];
        }
        return -1f;
    }

    public float getTrend(int time, int oldTime)
    {
        if (values.Count > 1)
        {
            return values[time] / values[oldTime];
        }
        return -1f;
    }

    // profit/deficit
    public float getNet()
    {
        if (values.Count > 0)
        {
            return values[values.Count - 1] - values[0];
        }
        return 0f;
    }

    public string getName()
    {
        return key;
    }

    public float getDividend()
    {
        return dividend;
    }
}
