using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockManager
{
    private static string elphaba = "QWERTYUIOPASDFGHJKLZXCVBNM";
    private static int maxChars = 4, maxShares = 10000, stocks = 100;
    private static float chancePayout = .1f, maxDivi = 1.1f, 
        maxVal = float.MaxValue, startBal = 10000f;

    public List<Stock> portfolio;
    float balance;

    public static StockManager instance;

    public StockManager() : this(stocks) {}

    public StockManager(int num)
    {
        portfolio = new List<Stock>(stocks);
        addStocks(num);
        balance = startBal;
        instance = this;
    }

    public bool addEntry() {
        return addEntry(1);
    }

    public bool addEntry(int num) {
        return num + portfolio.Count <= stocks ? addStocks(num) : false;
    }

    bool addStocks(int num) {
        bool payout = false;
        num = num > stocks ? stocks : num;
        for (int i = num - 1; i >= 0; i--) {
            payout = Random.Range(0f, 1f) < chancePayout;
            portfolio.Add(new Stock(keygen(), payout ? Random.Range(1f, maxDivi) : 1f, 
                Random.Range(0.001f, maxVal), Random.Range(1, maxShares)));
        }
        return true;
    }

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

    string keygen() {
        string key = "";
        for (int i = Random.Range(1, maxChars); i > 0; i--) {
            key += elphaba[Random.Range(0, elphaba.Length - 1)];
        }
        return key;
    }
}
