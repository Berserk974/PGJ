using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {
	private bool canDestroy;
	private float tVar;
	public float timeDelete;
	// Use this for initialization
	void Start () {
		tVar  = 0;
		canDestroy = false;
	}
	
	// Update is called once per frame
	void Update () {




		if( canDestroy) {
			tVar+= Time.deltaTime;
			if(tVar>timeDelete){
				Destroy(gameObject);
			}
		}
	}



	void OnTriggerEnter2D(Collider2D other) {

		canDestroy= true;
	}
}
