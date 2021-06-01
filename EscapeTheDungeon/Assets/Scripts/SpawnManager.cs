using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float enemyRespawnTimer;

    [SerializeField]
    private GameObject ratPrefab;

    GameObject[] ratSpawnPoints;
    GameObject[] enemySpawnPoints;
    public int thisEnemy = 0;

    public int enemyHit;

    Laser laser;

    void Start() {
        laser = gameObject.GetComponent<Laser>();
        ratSpawnPoints = GameObject.FindGameObjectsWithTag("RatSpawn");
        enemySpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawn");
        
        for(int i = 0; i < enemySpawnPoints.Length; i++)
        {
            GameObject currentEnemy = (GameObject)Instantiate(enemyPrefab, enemySpawnPoints[i].transform.position, Quaternion.identity);

            currentEnemy.name = string.Format("Enemy_{0}", thisEnemy);
            thisEnemy++;
        }

        for(int i = 0; i < ratSpawnPoints.Length; i++)
        {
            Instantiate(ratPrefab, ratSpawnPoints[i].transform.position, Quaternion.identity);
        }
    }

    public void SpawnEnemy(){
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine(){
        Debug.Log(enemyHit);
        yield return new WaitForSeconds(enemyRespawnTimer);

        if(enemyHit == 0){
            GameObject currentEnemy = (GameObject)Instantiate(enemyPrefab, enemySpawnPoints[0].transform.position, Quaternion.identity);
            currentEnemy.name = string.Format("Enemy_{0}", 0);
        }
        else if(enemyHit == 1){
            GameObject currentEnemy = (GameObject)Instantiate(enemyPrefab, enemySpawnPoints[1].transform.position, Quaternion.identity);
            currentEnemy.name = string.Format("Enemy_{0}", 1);
        }
        else if(enemyHit == 2){
            GameObject currentEnemy = (GameObject)Instantiate(enemyPrefab, enemySpawnPoints[2].transform.position, Quaternion.identity);
            currentEnemy.name = string.Format("Enemy_{0}", 2);
        }
        else if(enemyHit == 3){
            GameObject currentEnemy = (GameObject)Instantiate(enemyPrefab, enemySpawnPoints[3].transform.position, Quaternion.identity);
            currentEnemy.name = string.Format("Enemy_{0}", 3);
        }
        else if(enemyHit == 4){
            GameObject currentEnemy = (GameObject)Instantiate(enemyPrefab, enemySpawnPoints[4].transform.position, Quaternion.identity);
            currentEnemy.name = string.Format("Enemy_{0}", 4);
        }
        
    }
}
