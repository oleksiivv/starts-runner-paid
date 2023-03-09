using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Vector3 instPos;
    public Vector3 startPos;

    void Update(){
        transform.position=Vector3.MoveTowards(transform.position,new Vector3(instPos.x,transform.position.y,transform.position.z),0.0775f*Time.timeScale*AstronautLife.alive);

        
        if(instPos.x == transform.position.x){
            transform.position-=new Vector3(transform.localScale.x*2-0.1f,0,0);
        }
            
    }

    void cleanAllChilds(){
        for(int i=2;i<transform.childCount;i++){
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
