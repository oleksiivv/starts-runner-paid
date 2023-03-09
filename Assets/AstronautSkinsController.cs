using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautSkinsController : MonoBehaviour
{
    public GameObject[] astronauts;

    public ButtonsListener listener;

    void Start(){
        foreach(var obj in astronauts)obj.SetActive(false);

        astronauts[PlayerPrefs.GetInt("CurrentPlayerMaterial",0)].SetActive(true);

        listener.astronaut = astronauts[PlayerPrefs.GetInt("CurrentPlayerMaterial",0)].GetComponent<Astronaut>();
        listener.setMoveButtonListener();
    }
}
