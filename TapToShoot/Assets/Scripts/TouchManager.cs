 using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
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

        	if (Physics.Raycast(mousePosN, mousePosF-mousePosN, out hit))
        	{
            	//Instantiate(explosion, hit.transform.position, Quaternion.identity);
            	Destroy(hit.transform.gameObject);
            }
		}
	}
}
