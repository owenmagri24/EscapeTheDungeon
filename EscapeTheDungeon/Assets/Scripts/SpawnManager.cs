using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject enemyPrefab2;

    [SerializeField]
    private GameObject enemyPrefab3;

    [SerializeField]
    private GameObject enemyPrefab4;

    [SerializeField]
    private GameObject enemyPrefab5;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private Transform spawnPoint2;

    [SerializeField]
    private Transform spawnPoint3;

    [SerializeField]
    private Transform spawnPoint4;

    [SerializeField]
    private Transform spawnPoint5;

    [SerializeField]
    private float enemyRespawnTimer;

    public void SpawnEnemy(){
        StartCoroutine(SpawnEnemyRoutine());
    }

    public void SpawnEnemy2(){
        StartCoroutine(SpawnEnemyRoutine2());
    }

    public void SpawnEnemy3(){
        StartCoroutine(SpawnEnemyRoutine3());
    }

    public void SpawnEnemy4(){
        StartCoroutine(SpawnEnemyRoutine4());
    }

    public void SpawnEnemy5(){
        StartCoroutine(SpawnEnemyRoutine5());
    }

    IEnumerator SpawnEnemyRoutine(){
        yield return new WaitForSeconds(enemyRespawnTimer);

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    IEnumerator SpawnEnemyRoutine2(){
        yield return new WaitForSeconds(enemyRespawnTimer);

        Instantiate(enemyPrefab2,spawnPoint2.position, Quaternion.identity);
    }

    IEnumerator SpawnEnemyRoutine3(){
        yield return new WaitForSeconds(enemyRespawnTimer);

        Instantiate(enemyPrefab3,spawnPoint3.position, Quaternion.identity);
    }

    IEnumerator SpawnEnemyRoutine4(){
        yield return new WaitForSeconds(enemyRespawnTimer);

        Instantiate(enemyPrefab4,spawnPoint4.position, Quaternion.identity);
    }

    IEnumerator SpawnEnemyRoutine5(){
        yield return new WaitForSeconds(enemyRespawnTimer);

        Instantiate(enemyPrefab5,spawnPoint5.position, Quaternion.identity);
    }
}
