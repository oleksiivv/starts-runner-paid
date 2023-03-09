using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AstronautScore : MonoBehaviour
{
    public Text scoreLabel, hiScoreLabel;
    private int score=0;
    private float acceleration;

    void Start(){
        acceleration=1;
        score=0;
        showHi();
        show();
        StartCoroutine(scoreUpdate());
    }

    IEnumerator scoreUpdate(){
        while(true){
            if(AstronautLife.alive==1){
                score++;
                Debug.Log("Score:"+score.ToString());
                if(score > PlayerPrefs.GetInt("hi")){
                    PlayerPrefs.SetInt("hi", score);
                    showHi();
                    GameUI.newHI = true;
                }
                show();
            }
            yield return new WaitForSeconds(0.6f*acceleration);

            if(acceleration>0.1f){
                acceleration*=0.99f;
            }
        }
    }


    public void show(){
        scoreLabel.text = score.ToString();
    }

    public void showHi(){
        hiScoreLabel.text = PlayerPrefs.GetInt("hi").ToString();
    }
}
