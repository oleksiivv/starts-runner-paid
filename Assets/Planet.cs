using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private float rotSpeed;

    void Start(){
        rotSpeed = Random.Range(0.1f, 0.5f);
    }

    void Update(){
        transform.Rotate(0, 0, rotSpeed*Time.timeScale*AstronautLife.alive);
    }
}
