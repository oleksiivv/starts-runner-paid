using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautFX : MonoBehaviour
{
    public ParticleSystem rightCollision, leftCollision;

    public ParticleSystem coinGetEffect, itemGetEffect;

    public ParticleSystem runEffect;


    public void playRightCollision(){
        rightCollision.Play();
    }

    public void playLeftCollision(){
        leftCollision.Play();
    }

    public void playCoinGetEffect(){
        coinGetEffect.Play();
    }

    public void playItemGetEffect(){
        itemGetEffect.Play();
    }

    public void playRunEffect(){
        runEffect.Play();
    }

    public void stopRunEffect(){
        runEffect.Stop();
    }


}
