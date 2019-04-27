using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Vector3 lastMousePos;
    public Vector3 offSet;
    public Vector3 initialPos;
    public float movementSmoothness = 3;


    /**
    * Hand Controller needed
    * 
    * Lateral movement
    * - W A S D controls? or Mouse Controls
    * 
    * Finger Control (Righty)
    * - A S D F SPACE?
    * - LShift A W D SPACE
    *
    * Finger Control (Lefty)
    * - ; L K J Space
    * - RShift ' P L Space
    */

    void Start(){
        initialPos = this.transform.position;
        lastMousePos = Input.mousePosition;
    }

    void Update(){
        
        LateralMovment();
    }

    

    void LateralMovment(){
        Vector3 deltaMouse = Input.mousePosition - lastMousePos;
        lastMousePos = Input.mousePosition;

        offSet += new Vector3(deltaMouse.x / (float)Screen.width - .5f, 0, deltaMouse.y / (float)Screen.height- .5f);

        this.transform.position = Vector3.Lerp(this.transform.position, initialPos + offSet, movementSmoothness * Time.deltaTime);
    }
}
