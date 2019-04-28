using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockManager
{
    //buy, sell, private keygen, constructor
    List<Stock> portfolio;
    float balance;

    public float getPortfolioValue(int time)
    {
        float total = 0f;
        for (int i = portfolio.Count - 1; i >= 0; i--)
        {
            total += portfolio[i].getValue(time);
        }
        return total;
    }

    public float getGross(int time)
    {
        float total = 0f;
        for (int i = portfolio.Count - 1; i >= 0; i--)
        {
            total += portfolio[i].getNet(time);
        }
        return total;
    }

    public float getBalance()
    {
        return balance;
    }

    public bool buy()
    {
        bool able = false;
        //TODO
        return able;
    }

    public bool sell()
    {
        bool able = false;
        //TODO
        return able;
    }
}
