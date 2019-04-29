using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockGraphicManager : MonoBehaviour
{

    public GameObject template;
    public Transform content;

    public TMP_Text clock;

    StockManager manager;
    List<StockGraphic> graphics = new List<StockGraphic>();

    // Start is called before the first frame update
    void Start()
    {
        manager = new StockManager();

        for(int i = 0; i < manager.portfolio.Count; i++){
            Instantiate(template, content.position, Quaternion.identity, content.transform);
        }

    }

    
    void Update(){
        UpdateGraphics();
    }


    int lastTime = 0;
    void UpdateGraphics(){
        int thisTime = (int)Time.timeSinceLevelLoad;
        clock.text = GameSecondsToTime(thisTime);
        if(lastTime == thisTime)
            return;

        for(int i = 0; i < graphics.Count; i++){
            graphics[i].UpdateGraphic(i, thisTime, manager.portfolio[i]);
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
