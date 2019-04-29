using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockGraphic : MonoBehaviour
{
    public TMP_Text symbol, shares,price, trend, dividend, transaction;
    public Button sell, buy, up, down;
    int index = 0;
    int time = 0;
    public void UpdateGraphic(int index, int time, Stock stock){
        this.index = index;
        this.time = time;
        symbol.text = stock.getName();
        shares.text = stock.getBought() + "/" + stock.getShares();
        price.text = "$" + stock.getValue(time);
        trend.text = stock.displayTrend(time) + "%";
        dividend.text = stock.displayDivi() + "%";
    }

    public void Buy(){
        StockManager.instance.buy(index, time, transactionCount);
    }

    public void Sell(){
        StockManager.instance.sell(index, time, transactionCount);
    }

    int transactionCount = 0;
    public void IncreaseTransactionCount(){
        transactionCount++;
        transaction.text = "" + transactionCount;
    }

    public void DecreaseTransactionCount(){
        transactionCount--;
        transaction.text = "" + transactionCount;
    }
}
