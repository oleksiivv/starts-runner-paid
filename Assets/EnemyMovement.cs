using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 targetPosition;

    public float speed;
    private bool destroyed=false;
    private bool creature=false;

    void Start(){
        creature = gameObject.name.ToLower().Contains("creature");
        if(creature){
            targetPosition*=2;
        }
    }

    void Update(){
        if(!destroyed)transform.position = Vector3.MoveTowards(transform.position,
                                                new Vector3(targetPosition.x, transform.position.y, transform.position.z),
                                                0.08f*speed*Time.timeScale* AstronautLife.alive);

        if(transform.position.x == targetPosition.x){
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider other){
        
        if(gameObject.tag == "Enemy" && other.gameObject.name.ToLower().Contains("coin")){
            Destroy(gameObject);
        }
        if(other.gameObject.name.ToLower().Contains("creature")){
            destroyed=true;
            StartCoroutine(fall());
            Invoke(nameof(clean), 5f);
        }
    
    }

    void OnCollisionEnter(Collision other){
        
        if(gameObject.tag == "Enemy" && other.gameObject.name.ToLower().Contains("coin")){
            Destroy(other.gameObject);
        }
    }



    IEnumerator fall(){
        while(true){
            transform.position = Vector3.MoveTowards(transform.position, 
            new Vector3(targetPosition.x, transform.position.y+10, transform.position.z),
                                                0.4f*speed*Time.timeScale* AstronautLife.alive);

            yield return new WaitForEndOfFrame();
        }
    }

    void clean(){
        Destroy(gameObject);
    }


}
