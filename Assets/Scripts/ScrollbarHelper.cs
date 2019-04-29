using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarHelper : MonoBehaviour
{

    Scrollbar scroll;

    // Start is called before the first frame update
    void Start()
    {
        scroll = this.GetComponent<Scrollbar>();

        
    }

    void Update(){
    }

    public void upButton(){
        scroll.value += .1f;
    }

    public void downButton(){
        scroll.value -= .1f;
    }

}
