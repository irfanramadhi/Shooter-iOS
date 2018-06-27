 using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour
{
    private float shootDelayCounter;

    public GameObject explosion;
    public float shootDelay = 0.75f;
    

    public int weaponDamage;

	// Use this for initialization
	void Start ()
    {
        //GameObject theEnemy = GameObject.Find("Cube(Clone)");
        //EnemyStats enemyStats = theEnemy.GetComponent<EnemyStats>();
        weaponDamage = 10;

	}
	
	// Update is called once per frame
	void Update () 
	{
        shootDelayCounter -= Time.deltaTime;

		if(Input.GetMouseButton(0))
		{
			Vector3 mousePosFar = new Vector3(Input.mousePosition.x,
												 Input.mousePosition.y,
												 Camera.main.farClipPlane);
			Vector3 mousePosNear = new Vector3(Input.mousePosition.x,
												 Input.mousePosition.y,
												 Camera.main.nearClipPlane);
			Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
			Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
			//Debug.DrawRay(mousePosN,mousePosF-mousePosN, Color.green);


			RaycastHit hit;

        	if (Physics.Raycast(mousePosN, mousePosF-mousePosN, out hit) && shootDelayCounter < 0)
        	{
                GameObject theEnemy = GameObject.FindGameObjectWithTag("Enemy");
                EnemyStats enemyStats = theEnemy.GetComponent<EnemyStats>();
                //Instantiate(explosion, hit.transform.position, Quaternion.identity);
                enemyStats.healthPoint -= weaponDamage;
                Debug.Log(enemyStats.healthPoint);
            	//Destroy(hit.transform.gameObject);
                shootDelayCounter = shootDelay;
            }
		}
	}
}
