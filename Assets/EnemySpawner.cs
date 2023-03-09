using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float[] positionsZ;
    public GameObject[] enemies;
    public GameObject[] creatures;

    public int positionX, creaturePositionX;

    public float delay;

    public List<int> bigEnemiesid;

    void Start(){
        StartCoroutine(spawn());
        StartCoroutine(spawnCreature());
    }

    IEnumerator spawn(){
        while(true){
            if(AstronautLife.alive == 1){
                int enemyId = Random.Range(0, enemies.Length);
                if(bigEnemiesid.Contains(enemyId)){
                    Instantiate(enemies[enemyId], 
                                new Vector3(positionX, enemies[enemyId].transform.position.y, enemies[enemyId].transform.position.z),
                                enemies[enemyId].transform.rotation);
                }
                else{
                    Instantiate(enemies[enemyId], 
                                new Vector3(positionX, enemies[enemyId].transform.position.y, positionsZ[Random.Range(0, positionsZ.Length)]),
                                enemies[enemyId].transform.rotation);

                }
            }
            yield return new WaitForSeconds(delay);

            if(delay>0.8f)delay*=0.985f;
            Debug.Log("Delay:"+delay.ToString());
        }
    }

    IEnumerator spawnCreature(){
        while(true){
            yield return new WaitForSeconds(delay*4*Random.Range(0.7f, 2f));

            if(AstronautLife.alive == 1){
                int enemyId = Random.Range(0,creatures.Length);
                Instantiate(creatures[enemyId], 
                                new Vector3(creaturePositionX, creatures[enemyId].transform.position.y+5, positionsZ[Random.Range(0, positionsZ.Length)]),
                                creatures[enemyId].transform.rotation);
            }
            

            if(delay>0.8f)delay*=0.985f;
            Debug.Log("Delay:"+delay.ToString());
        }
    }
}
