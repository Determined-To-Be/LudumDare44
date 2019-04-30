using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockManager
{
    private static int maxStocks = 100;
    public static int endOfTime = 480; // 9-5!
    private static float startBal = 50000f;

    public List<Stock> portfolio;
    float balance;

    public StockManager() : this(maxStocks) {}

    public StockManager(int num)
    {
        portfolio = new List<Stock>(maxStocks);
        addStocks(num);
        balance = startBal;
    }

    public bool addEntry() {
        return addEntry(1);
    }

    public bool addEntry(int num) {
        return num + portfolio.Count <= maxStocks ? addStocks(num) : false;
    }

    bool addStocks(int num) {
        num = num > maxStocks ? maxStocks : num;
        for (int i = num - 1; i >= 0; i--) {
            portfolio.Add(new Stock(endOfTime));
        }
        return true;
    }

    public float getPortfolioValue(int time)
    {
        float total = 0f;
        for (int i = portfolio.Count - 1; i >= 0; i--)
        {
            total += portfolio[i].getValue(time) * portfolio[i].getBought();
        }
        return total;
    }

    public float getGross(int time)
    {
        float total = 0f;
        for (int i = portfolio.Count - 1; i >= 0; i--)
        {
            total += portfolio[i].getNet(time) * portfolio[i].getBought();
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
            portfolio[i].buy(num, time);
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
            balance += portfolio[i].getValue(time) * num;
        }
        return able;
    }

    public void doPayouts(int time)
    {
        for (int i = portfolio.Count - 1; i >= 0; i--)
        {
            balance += portfolio[i].getValue(time) * portfolio[i].getDivi() * portfolio[i].getBought();
        }
    }
}
