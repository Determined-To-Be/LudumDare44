using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockGraphic : MonoBehaviour
{
    public TMP_Text symbol, shares,price, trend, dividend, transaction;
    public Button sell, buy, up, down;
    public int index = 0;
    public int time = 0;

    public StockGraphicManager manager;

    public Popup newsPopup;
    public Button ticker;

    void Start(){
        manager = GameObject.FindGameObjectWithTag("StockManager").GetComponent<StockGraphicManager>();
        
        
        newsPopup = GameObject.FindObjectOfType<Popup>();
        

        ticker.onClick.AddListener(openPopup);
    }

    void openPopup(){
        newsPopup.openPopup(index, time, manager);
    }

    public void UpdateGraphic(int index, int time){
        Stock stock = manager.manager.portfolio[index];
        
        if(stock == null){

            Debug.Log("Hey stock at " + index + " is null pls fix");
            return;
        }

        this.index = index;
        this.time = time;
        symbol.text = stock.getName();
        shares.text = stock.getBought() + "/" + stock.getShares();
        price.text = "$" + (int)stock.getValue(time);
        trend.text = (int)stock.displayTrend(time) + "%";
        dividend.text = (int)stock.displayDivi() + "%";
        transaction.text = transactionCount + "";
    }

    public void Buy(){
        bool val = manager.manager.buy(index, time, transactionCount);
        if(!val)
            Debug.Log("Failed to buy " + manager.manager.portfolio[index]);

        UpdateGraphic(index, time);
    }

    public void Sell(){
        bool val = manager.manager.sell(index, time, transactionCount);

        if(!val)
            Debug.Log("Failed to sell " + manager.manager.portfolio[index]);

        UpdateGraphic(index, time);
    }

    int transactionCount = 0;
    public void IncreaseTransactionCount(){
        transactionCount++;
        transaction.text = "" + transactionCount;
    }

    public void DecreaseTransactionCount(){
        if(transactionCount <= 0)
            return;

        transactionCount--;
        transaction.text = "" + transactionCount;
    }
}
