using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockGraphicManager : MonoBehaviour
{
    public int endOfTime = 480; // 9-5!
    public int stockCount = 10;

    public GameObject template;
    public Transform content;

    public TMP_Text clock;

    public StockManager manager;
    public StockGraphic[] graphics;

    // Start is called before the first frame update
    void Start()
    {
        manager = new StockManager(stockCount);
        manager.initializeValues(endOfTime);
        graphics = new StockGraphic[manager.portfolio.Count];

        for(int i = 0; i < manager.portfolio.Count; i++){
            graphics[i] = (Instantiate(template, content.position, Quaternion.identity, content.transform).GetComponent<StockGraphic>());
            graphics[i].index = i;
        }


    }

    
    void Update(){
        UpdateGraphics();
    }


    int lastTime = 0;
    void UpdateGraphics(){
        int thisTime = (int)Time.timeSinceLevelLoad;
        if(lastTime == thisTime)
            return;
            
        clock.text = GameSecondsToTime(thisTime);

        for(int i = 0; i < graphics.Length; i++){
            graphics[i].UpdateGraphic(i, thisTime);
        }
    }

    string GameSecondsToTime(int seconds){
        int hour = (seconds / 60) + 9 % 13;
        int minutes = seconds % 60;

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
