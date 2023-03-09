using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AstronautCoinsController : MonoBehaviour
{
    public Text coinsLabel;

    void Start(){
        show();
    }

    public void updateValue(int n){
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")+n);
        show();
    }

    void show(){
        coinsLabel.text = PlayerPrefs.GetInt("coins").ToString();
    }
}
