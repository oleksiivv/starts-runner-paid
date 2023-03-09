﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    public Text fpsText;
    // Start is called before the first frame update
    void Start()
    {
        
        Application.targetFrameRate=40;


        fpsText.gameObject.SetActive(!true);
    }
    int fps;
    // Update is called once per frame
    void Update()
    {
        fps=((int)(1f / Time.unscaledDeltaTime));

        fpsText.text=fps.ToString();
    }

}
