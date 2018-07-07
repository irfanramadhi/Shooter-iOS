using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{

    public GameObject EnemyPrefab;
    private bool allowSpawn = true;
    public int nextEnemyNumber;
    public Vector3 center;
    public Vector3 size;
    float timer = 0.0f;

	// Use this for initialization
	void Start ()
    {
        nextEnemyNumber = 0;
        SpawnEnemy();

	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        int seconds = Mathf.RoundToInt(timer % 60);
        Debug.Log("Seconds : " + seconds);
	
        if(seconds % 4 == 0)
        {
            SpawnEnemy();
            allowSpawn = false;
        }
        if(seconds % 4 != 0)
        {
            allowSpawn = true;
        }

	}

    public void SpawnEnemy()
    {
        if(allowSpawn == true)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            var enemyClone = Instantiate(EnemyPrefab, pos, Quaternion.identity);
            enemyClone.name = "Target_" + nextEnemyNumber;
            nextEnemyNumber++;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

}
