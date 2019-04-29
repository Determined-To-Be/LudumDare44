using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Popup : MonoBehaviour
{
    public TMP_Text headline;
    public GameObject popup;


    public void openPopup(int i, int time, StockGraphicManager manager){
        headline.text = manager.manager.portfolio[i].getNews(time);

        popup.SetActive(true);
    }

    public void closePopup(){
        popup.SetActive(false);
    }


}
