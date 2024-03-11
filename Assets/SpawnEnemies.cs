using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : NetworkBehaviour
{
    [SerializeField] GameObject enemyPrefab;

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
        float randomX = Random.Range(-8, 9);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);
        GameObject enemy = 
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.down * enemySpeed;
        NetworkServer.Spawn(enemy);
        Destroy(enemy, 10f);
    }

}
