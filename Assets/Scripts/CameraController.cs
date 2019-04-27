using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform follwObj;
    public float followSmoothness = 3f;
    public Vector3 offSet;
    public bool stopFollow = false;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(follwObj == null)
            return;
        if(stopFollow == true)
            return;
        
        this.transform.position =  Vector3.Lerp(this.transform.position, offSet + follwObj.position, followSmoothness * Time.deltaTime);
    }
}
