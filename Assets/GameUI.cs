using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class GameUI : MonoBehaviour
{
    public GameObject pausePanel;

    public GameObject deathPanel;

    public GameObject[] newHiPanel;

    public static bool newHI = false;
    public ScenesManager scenes;

#if UNITY_IOS
    private string gameID = "4302110";
#else
    private string gameID = "4302111";
#endif

    private static int addCnt=1;

    public GameObject[] studyPanels;

    public AdmobController admob;

    void Start(){
        newHI = false;

        Advertisement.Initialize(gameID, false);
    }


    public void pause(){
        Time.timeScale = 0;
        pausePanel.SetActive(true);

        if(addCnt%3 == 0){
            // if(Advertisement.IsReady("Interstitial_Android")){
            //     Advertisement.Show("Interstitial_Android");
            // }
        }
        addCnt++;
    }

    public void resume(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void openScene(int id){
        Time.timeScale=1;
        scenes.openScene(id);
    }

    public void restart(){
        openScene(Application.loadedLevel);
    }

    public void setDeathPanelActive(bool active){
        if(active && newHI){
            foreach(var panel in studyPanels){
                panel.SetActive(false);
            }
            foreach(var panel in newHiPanel){
                panel.SetActive(true);
            }
        }
        else{
            if(addCnt%3 == 0){
                // if(!Advertisement.IsReady("Interstitial_Android")){
                //     Advertisement.Show("Interstitial_Android");
                // }
                // else{
                //     admob.showIntersitionalAd();
                // }
            }
            foreach(var panel in studyPanels){
                panel.SetActive(false);
            }
            addCnt++;
            deathPanel.SetActive(active);
        }
    }

    public void setNewHiPanelActive(bool active){
        foreach(var panel in newHiPanel){
            panel.SetActive(active);
        }
        deathPanel.SetActive(!active);
    }
}
