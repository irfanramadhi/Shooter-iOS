using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{

    public GameObject EnemyPrefab;

    public int nextEnemyNumber;
    public Vector3 center;
    public Vector3 size;

	// Use this for initialization
	void Start ()
    {
        nextEnemyNumber = 0;
        SpawnEnemy();

	}
	
	// Update is called once per frame
	void Update ()
    {
	
        if(Input.GetKey(KeyCode.Q))
        {
            SpawnEnemy();
        }

	}

    public void SpawnEnemy()
    {

        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x /2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        var enemyClone = Instantiate(EnemyPrefab, pos, Quaternion.identity);
        enemyClone.name = "Target_" + nextEnemyNumber;
        nextEnemyNumber++;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

}
