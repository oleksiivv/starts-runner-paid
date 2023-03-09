using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{

    int dx=0;

    bool played=false;

    public float playerLen;

    private Vector2 startTouchPosition, endTouchPosition;
    Vector2 screenPosition;

    private bool jump = true;
    public Animator anim;

    public Rigidbody rigidbody;

    private int prevDx;

    public AstronautFX fx;
    
    void Start()
    {
  
      screenPosition=Vector2.zero;
      AstronautLife.alive=1;

    }


    // Update is called once per frame
    private void Update()
    {
        if(AstronautLife.alive!=1)return;
        
        if(Input.GetMouseButtonDown(0) && Time.timeScale == 1){
            screenPosition= new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        anim.SetBool("run", jump);



        if(Input.GetKeyUp(KeyCode.LeftArrow)){
          if(dx < 1){

            prevDx = dx;
            dx++;

            if(!played){
                anim.SetBool("leftFlip", true);
                played=true;
            }

            if(!IsInvoking(nameof(resetPlayedvalue))){
                Invoke(nameof(resetPlayedvalue), 0.5f);
            }
            //fx.stopRunEffect();

          }
        }

        if(Input.GetKeyUp(KeyCode.RightArrow)){
          if(dx > -1){

            prevDx = dx;
            dx--;

            if(!played){
                anim.SetBool("rightFlip", true);
                played=true;
            }

            if(!IsInvoking(nameof(resetPlayedvalue))){
                Invoke(nameof(resetPlayedvalue), 0.5f);
            }
            //fx.stopRunEffect();

          }
        }



        transform.position=Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,transform.position.y,-dx*playerLen), 0.05f*Time.timeScale);
    }

    public void move(){

        if(AstronautLife.alive!=1)return;

        endTouchPosition=new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Debug.Log(screenPosition.y-endTouchPosition.y);

        if(screenPosition.y+30<endTouchPosition.y && Mathf.Abs(screenPosition.x-endTouchPosition.x) <100 && jump){
          
          //jump
          rigidbody.AddForce(Vector3.up*6, ForceMode.Impulse);
          jump=false;
          fx.stopRunEffect();
        
        }

        else if(screenPosition.y-40>endTouchPosition.y && Mathf.Abs(screenPosition.x-endTouchPosition.x) < 100){
          
          //land
          rigidbody.AddForce(Vector3.up*-6, ForceMode.Impulse);
          fx.stopRunEffect();

        }

        else{
            if(screenPosition.x+10<endTouchPosition.x){
                if(dx>-1){

                    prevDx = dx;
                    dx--;
                    if(!played){
                        anim.SetBool("rightFlip", true);
                        played=true;
                    }

                    if(!IsInvoking(nameof(resetPlayedvalue))){
                        Invoke(nameof(resetPlayedvalue), 0.5f);
                    }
                    
                }
            }
            else if(screenPosition.x-10>endTouchPosition.x){
                if(dx<1){

                    prevDx = dx;
                    dx++;

                    if(!played){
                        anim.SetBool("leftFlip", true);
                        played=true;
                    }
                    
                    if(!IsInvoking(nameof(resetPlayedvalue))){
                        Invoke(nameof(resetPlayedvalue), 0.5f);
                    }

                }
            }
        }



    }

    void resetPlayedvalue(){
        played=false;
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag=="Ground"){
            Debug.Log("landed");
            jump=true;
        }
    }

    public void jumpBack(){
        switch (dx)
        {
            case -1:
                dx = 0;
                fx.playLeftCollision();
                break;
            case 0:
                dx = prevDx;
                if(dx == -1) fx.playLeftCollision();
                else fx.playRightCollision();
                break;
            case 1:
                fx.playRightCollision();
                dx = 1;
                break;
        }

        
        
    }
}
