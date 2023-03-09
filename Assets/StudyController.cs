using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyController : MonoBehaviour
{
    public GameObject[] studyElements;

    void Start(){
        if(PlayerPrefs.GetInt("studied",-1)==-1){
            foreach(var elem in studyElements)elem.SetActive(true);
            PlayerPrefs.SetInt("studied",1);

            Invoke(nameof(hideStudy), 11);
        }
        else{
            foreach(var elem in studyElements)elem.SetActive(false);
        }
    }

    void hideStudy(){
        foreach(var elem in studyElements)elem.SetActive(false);
    }
}
