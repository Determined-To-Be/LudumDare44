using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    public void loadScene(int i ){
        SceneManager.LoadScene(i);
    }

    public void quit(){
        Application.Quit();
    }
}
