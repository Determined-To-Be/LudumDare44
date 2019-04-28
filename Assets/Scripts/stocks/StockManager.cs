using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockManager
{
    //private keygen, constructor
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

    public bool buy(int i, int time)
    {
        return buy(i, 1, time);
    }

    public bool buy(int i, int num, int time)
    {
        float val = portfolio[i].getValue(time) * num;
        bool able = portfolio[i].stockAvail(num) && balance >= val;
        if (able) {
            portfolio[i].buy(num);
            balance -= val;
        }
        return able;
    }

    public bool sell(int i, int time)
    {
        return sell(i, 1, time);
    }

    public bool sell(int i, int num, int time)
    {
        bool able = portfolio[i].getBought() >= num;
        if (able) {
            portfolio[i].sell(num);
            balance += portfolio[i].getValue() * num;
        }
        return able;
    }
}
