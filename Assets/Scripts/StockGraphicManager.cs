using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockGraphicManager : MonoBehaviour
{
    public int stockCount = 10;

    public bool gameRunning = true;

    public GameObject template;
    public Transform content;

    public TMP_Text clock, balance, net, gross;

    public StockManager manager;
    public StockGraphic[] graphics;

    public TMP_Text endOfGameText;
    public GameObject endOfGamePopup;

    // Start is called before the first frame update
    void Start()
    {
        manager = new StockManager(stockCount);
        graphics = new StockGraphic[manager.portfolio.Count];

        for(int i = 0; i < manager.portfolio.Count; i++){
            graphics[i] = (Instantiate(template, content.position, Quaternion.identity, content.transform).GetComponent<StockGraphic>());
            graphics[i].index = i;
        }

        
    }

    
    void Update(){
        if(gameRunning){
            UpdateGraphics();
            return;
        }

        endOfGameText.text = "You made $" + (int)manager.getPortfolioValue(StockManager.endOfTime - 1) + " today!";
        endOfGamePopup.SetActive(true);
    }

    int lastTime = 0;
    void UpdateGraphics(){
        int thisTime = (int)Time.timeSinceLevelLoad;
        if(lastTime == thisTime)
            return;
        if(thisTime >= StockManager.endOfTime)
            gameRunning = false;
            
        clock.text = GameSecondsToTime(thisTime);
        balance.text = "$" + (int)manager.getBalance();
        gross.text = "$" + (int)manager.getGross(thisTime);
        net.text = "$" + (int)manager.getPortfolioValue(thisTime);

        for(int i = 0; i < graphics.Length; i++){
            graphics[i].UpdateGraphic(i, thisTime);
        }
    }

    string GameSecondsToTime(int seconds){
        int hour = (seconds / Stock.interval) + 9 % 13;
        int minutes = seconds % Stock.interval;

        string ampm = "AM";
        string leadingZero = "";
        if(hour < 9){
            hour++;
            ampm = "PM";
        }

        if(minutes < 10)
            leadingZero = "0";

        return hour + ":" + leadingZero + minutes + " " + ampm;
    }
}
