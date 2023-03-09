using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float[] positionsZ;
    public GameObject[] coins;

    public int positionX;

    public float delay;

    void Start(){
        StartCoroutine(spawn());
    }

    IEnumerator spawn(){
        while(true){
            if(AstronautLife.alive == 1){
                int coinId = Random.Range(0, coins.Length);

                Instantiate(coins[coinId], 
                            new Vector3(positionX, coins[coinId].transform.position.y, positionsZ[Random.Range(0, positionsZ.Length)]),
                            coins[coinId].transform.rotation);
            }

            yield return new WaitForSeconds(delay);
        }
    }
}
