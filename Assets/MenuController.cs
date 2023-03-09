using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text hiLabel;
    public GameObject hiPanel;

    public ScenesManager scenes;

    public Text gemsCnt;

    void Start(){   
        if(PlayerPrefs.GetInt("hi",-1)==-1){
            hiPanel.SetActive(false);
        }
        else{
            hiPanel.SetActive(true);
            hiLabel.text = PlayerPrefs.GetInt("hi").ToString();
        }


        if(PlayerPrefs.GetInt("first",-1)==-1){
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins",0)+100);
            PlayerPrefs.SetInt("first",1);
        }
        gemsCnt.GetComponent<Text>().text=PlayerPrefs.GetInt("coins").ToString();
    }

    public void openScene(int id){
        scenes.openScene(id);
    }
}
