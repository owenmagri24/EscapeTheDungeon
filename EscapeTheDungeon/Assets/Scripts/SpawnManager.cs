using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float enemyRespawnTimer;

    public void SpawnEnemy(){
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine(){
        yield return new WaitForSeconds(enemyRespawnTimer);

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

}
