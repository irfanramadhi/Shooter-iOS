using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int healthPoint;

	// Use this for initialization
	void Start ()
    {

        healthPoint = 20;

	}
	
	// Update is called once per frame
	void Update ()
    {
		
        if(healthPoint <= 0)
        {
            Destroy(this.gameObject);
        }

	}
}
