using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : NetworkBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] float spawnInterval = 1f;

    [SerializeField] float enemySpeed = 1f;

    public override void OnStartServer()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy() 
    {
        int indexEnemy = Random.Range(0, enemyPrefabs.Length);

        float randomX = Random.Range(-8, 9);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);
        GameObject enemy =
            Instantiate(enemyPrefabs[indexEnemy], spawnPosition, Quaternion.identity);
        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.down * enemySpeed;
        NetworkServer.Spawn(enemy);
        Destroy(enemy, 10f);
    }

}
