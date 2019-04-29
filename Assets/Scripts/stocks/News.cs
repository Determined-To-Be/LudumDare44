using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class News
{
    public enum Trend { good, bad, neutral };
    private static string error = "404 News Not Found";
    private static string magicSeq = "____";
    private static string special = "There are many rumors surrounding ____, maybe they're true???";

    private static string[] justNews = {
        "No events surrounding ____ currently."
    };

    private static string[] goodNews = {
        "BREAKING NEWS: ____ announces their yearly profits went up 20% from last year",
        "NEWS FEED: Why this analyst sees a buying oppurtunity in ____",
        "'We can expect good things from ____ in the near future!' - X. Pert",
        "FROM: Dad; Hey, my ____ stock is going up with no signs of stopping soon!"
    };

    private static string[] badNews = {
        "BREAKING NEWS: ____ announces that there is a shortage of stock.",
        "Confucious say, ____ will take a hit very soon.",
        "NEWS FEED: Why people are running away from ____",
        "FROM: Dad; Yo, my ____ stock just took a hit. I'd sell if I were you!"
    };

    /**
     * will return a different news each time it's called
     * format by replacing the magic sequence
     */
    public static string getTemplate(Trend trend)
    {
        string temp = "";
        switch (trend)
        {
            case Trend.good:
                temp = goodNews[Random.Range(0, goodNews.Length - 1)];
                break;
            case Trend.bad:
                temp = badNews[Random.Range(0, badNews.Length - 1)];
                break;
            case Trend.neutral:
                temp = justNews[Random.Range(0, justNews.Length - 1)];
                break;
            default:
                break;
        }
        return temp;
    }

    public static string getMagicSeq()
    {
        return magicSeq;
    }

    public static string errorMsg()
    {
        return error;
    }

    public static string getSpecial()
    {
        return special;
    }
}
