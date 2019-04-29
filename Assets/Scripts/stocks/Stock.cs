using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock
{
    public static int interval = 60; // time projection for news
    private static string elphaba = "QWERTYUIOPASDFGHJKLZXCVBNM";
    private static int maxChars = 4, maxShares = 1000;
    private static float maxDivi = 1.1f, chancePayout = .1f, maxVal = 10000f, 
        minVal = 0.001f, chanceFlip = 0.1f, discr = 0.1f;
    
    List<float> values = new List<float>();
    string key;
    float dividend;
    int shares, myShares, bought;

    public Stock(int gameTime) {
        this(keygen(), Random.Range(0f, 1f) < chancePayout ? Random.Range(1f, maxDivi) : 1f,
            Random.Range(minVal, maxVal), Random.Range(minVal, maxVal), Random.Range(1, maxShares), gameTime);
    }

    public Stock(string key, float dividend, float value, float value2, int shares, int gameTime)
    {
        this.key = key;
        this.dividend = dividend;
        if (specialKey())
        {
            int j = Random.Range(69f, 420f);
            for (int i = 0; i < gameTime; i++)
            {
                values.Add(j);
                j -= j / gameTime;
            }
            values.Add(float.MaxValue);
            this.shares = 1;
        }
        else
        {
            values.Add(value);
            values.Add(value);
            this.shares = shares;

            for (int i = gameTime; i >= 2; i--)
            {
                values.Add((getTrend() * Random.Range(0f, 1f) < chanceFlip ? -1f : 1f + Random.Range(-discr, discr)) * getValue());
            }
        }
        myShares = bought = 0;
    }

    public void buy() {
        buy(1);
    }

    public void buy(int num) {
        myShares += num;
    }

    public bool stockAvail() {
        return stockAvail(1);
    }

    public bool stockAvail(int num) {
        return shares >= myShares + num;
    }

    public void sell() {
        sell(1);
    }

    public void sell(int num) {
        myShares -= num;
    }

    public void setValue(float val)
    {
        values.Add(val >= 0f ? val : 0f);
    }

    public float getValue()
    {
        return values.Count > 0 ? values[values.Count - 1] : -1f;
    }

    public float getValue(int time)
    {
        return time >= 0 && values.Count > 0 ? values[time] : -1f;
    }

    public float displayTrend() {
        return getTrend() - 1f;
    }
    
    public float displayTrend(int time) {
        return (getTrend(time) - 1f) * 100f;
    }

    public float getTrend()
    {
        return values.Count > 1 ? values[values.Count - 1] / values[values.Count - 2] : -1f;
    }

    public float getTrend(int time)
    {
        return values.Count > 1 && time >= 0 ? values[time] / values[time - 1] : -1f;
    }

    public float getTrend(int time, int oldTime)
    {
        return values.Count > 1 && time > oldTime && oldTime >= 0? values[time] / values[oldTime] : -1f;
    }

    // profit/deficit
    public float getNet()
    {
        return values.Count > 0 ? values[values.Count - 1] - values[0] : 0f;
    }

    // profit/deficit
    public float getNet(int time)
    {
        return values.Count > 0 && time >= 0 ? values[time] - values[bought] : 0f;
    }

    public int getBought() {
        return bought;
    }

    // time at purchase
    public void setBought()
    {
        setBought(0);
    }

    public int getShares(){
        return shares;
    }

    // time at purchase
    public void setBought(int time)
    {
        bought = time >= 0 ? time : 0;
    }

    public string getName()
    {
        return key;
    }

    public float getDivi()
    {
        return dividend;
    }

    public float displayDivi() {
        return (dividend - 1f) * 100f;
    }

    public string getNews(int time)
    {
        if (specialKey)
        {
            return News.getSpecial().Replace(News.getMagicSeq(), key);
        }
        bool able = time >= 0;
        News.Trend temp = News.Trend.neutral;
        if (able) {
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
        }
        return able ? News.getTemplate(temp).Replace(News.getMagicSeq(), key) : News.errorMsg();
    }

    string keygen()
    {
        string key = "";
        for (int i = Random.Range(1, maxChars); i > 0; i--)
        {
            key += elphaba[Random.Range(0, elphaba.Length - 1)];
        }
        return key;
    }

    bool specialKey()
    {
        // our initials ;-)
        return key == "SMB" || "JGN";
    }
}
