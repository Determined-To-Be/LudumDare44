using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock
{
    private static int interval = 60; // time projection for news
    
    List<float> values = new List<float>();
    string key;
    float dividend;
    int shares, myShares, bought;

    public Stock(string key, float dividend, float value, int shares)
    {
        this.key = key;
        this.dividend = dividend;
        values.Add(value);
        this.shares = shares;
        myShares = bought = 0;
    }

    public void setValue(float val)
    {
        values.Add(val);
    }

    public float getValue()
    {
        return values.Count > 0 ? values[values.Count - 1] : -1f;
    }

    public float getValue(int time)
    {
        return time > 0 ? values[time] : -1f;
    }

    public float getTrend()
    {
        return values.Count > 1 ? values[values.Count - 1] / values[values.Count - 2] : -1f;
    }

    public float getTrend(int time)
    {
        return values.Count > 1 ? values[time] / values[time - 1] : -1f;
    }

    public float getTrend(int time, int oldTime)
    {
        return values.Count > 1 ? values[time] / values[oldTime] : -1f;
    }

    // profit/deficit
    public float getNet()
    {
        return values.Count > 0 ? values[values.Count - 1] - values[0] : 0f;
    }

    // profit/deficit
    public float getNet(int time)
    {
        return values.Count > 0 ? values[time] - values[bought] : 0f;
    }

    // time at purchase
    public void setBought()
    {
        bought = 0;
    }

    // time at purchase
    public void setBought(int time)
    {
        bought = time;
    }

    public string getName()
    {
        return key;
    }

    public float getDividend()
    {
        return dividend;
    }

    public string getNews(int time)
    {
        News.Trend temp = News.Trend.neutral;
        int future = time + interval;
        if (future >= values.Count)
        {
            future = values.Count - 1;
        }
        float trend = getTrend(future, time);
        if (trend > 1f)
        {
            temp = News.Trend.good;
        }
        else if (trend < 1f && trend > 0f)
        {
            temp = News.Trend.bad;
        }
        return News.getTemplate(temp).Replace(News.getMagicSeq(), key);
    }
}
