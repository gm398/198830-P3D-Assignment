using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] int maxEnemies = 100;
    private int currentEnemies = 0;
    [SerializeField] float spawnRate = 3f;
    private float spawnTimer = 0;
    [SerializeField] float spawnZoneDiameter = 3f;

    [SerializeField] GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        currentEnemies = 0;
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= 1/spawnRate && currentEnemies < maxEnemies)
        {
            spawnTimer = 0;
            SpawnEnemy();
            currentEnemies++;
        }
    }


    public void SpawnEnemy()
    {
        
        Vector3 spawnPoint = new Vector3(
            Random.Range(-spawnZoneDiameter, spawnZoneDiameter) + transform.position.x,
            transform.position.y, 
            Random.Range(-spawnZoneDiameter, spawnZoneDiameter) + transform.position.z);
        GameObject newSpawn = Instantiate(enemy, spawnPoint, transform.rotation);

        newSpawn.GetComponent<EnemyController>().SetTarget(target);
    }
}
