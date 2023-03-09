using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautCollisions : MonoBehaviour
{
    public GameUI ui;
    public Animator animator;
    public Astronaut moveSys;
    public AstronautCoinsController coinsController;

    public AstronautFX fx;

    private int errorsCnt;
    public Rigidbody rigidbody;

    void Start(){
        errorsCnt = 0;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Enemy"){
            callDeath();
        }
        if(other.gameObject.tag == "Coin"){
            Destroy(other.gameObject);
            coinsController.updateValue(1);

            fx.playCoinGetEffect();
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Enemy"){
            if(errorsCnt == 0){
                moveSys.jumpBack();
                errorsCnt++;
                Invoke(nameof(resetErrorsCnt), 1.5f);
            }
            else{
                callDeath();
            }
        }
        else{
            fx.playRunEffect();
        }
    }

    void resetErrorsCnt(){
        errorsCnt=0;
    }

    private void callDeath(){
        ui.setDeathPanelActive(true);
        AstronautLife.alive=0;
        rigidbody.AddRelativeForce(Vector3.up*3, ForceMode.Impulse);
        rigidbody.AddRelativeForce(Vector3.forward*-6, ForceMode.Impulse);
        //StartCoroutine(fallAnimation());
    }


    public IEnumerator fallAnimation(){
        while(true){
            //transform.eulerAngles -= new Vector3(10,0,0);
            transform.Translate(-Vector3.forward/15);
            transform.Translate(Vector3.up/15);

            yield return new WaitForEndOfFrame();
        }
    }
}
