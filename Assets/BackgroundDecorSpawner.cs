using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDecorSpawner : MonoBehaviour
{
    public float[] positionsZ;
    public GameObject[] decor;

    public int positionX;

    public float delay;

    void Start(){
        StartCoroutine(spawn());
    }

    IEnumerator spawn(){
        while(true){
            if(AstronautLife.alive == 1){
                int decorId = Random.Range(0, decor.Length);

                Instantiate(decor[decorId], 
                            new Vector3(positionX, decor[decorId].transform.position.y, positionsZ[Random.Range(0, positionsZ.Length)]),
                            decor[decorId].transform.rotation);
            }

            yield return new WaitForSeconds(delay);
        }
    }
}
