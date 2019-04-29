//Thanks Nischo
//From https://answers.unity.com/questions/1018336/is-there-a-way-to-click-on-a-render-texture-to-sel.html


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class RayCast : MonoBehaviour {
 
     public Camera portalCamera;
 
     void Update () 
     {
         if(Input.GetMouseButtonDown(0))
         {
             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
             // do we hit our portal plane?
             if (Physics.Raycast(ray, out hit)) 
             {
                 Debug.Log(hit.collider.gameObject);
                 
                 
                 var localPoint = hit.textureCoord;
                 // convert the hit texture coordinates into camera coordinates
                 Ray portalRay = portalCamera.ScreenPointToRay(new Vector2(localPoint.x * portalCamera.pixelWidth, localPoint.y * portalCamera.pixelHeight));
                 RaycastHit portalHit;
                 // test these camera coordinates in another raycast test
                 if(Physics.Raycast(portalRay, out portalHit))
                 {
                     Debug.Log(portalHit.collider.gameObject);
                 }
             }
         }
     
     }
 }