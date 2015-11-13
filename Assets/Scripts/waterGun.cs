using UnityEngine;
using System.Collections;

public class waterGun : MonoBehaviour
{
	public int bulletSpeed;
	public GameObject  projectile;
	public float interBullet;
	public int nbProjectile;
	public float timeReload;
	private int tNbProjectile;
	private float tvar;

	private float tVarReload;

	// Use this for initialization
	void Start ()
	{
		tvar = 0;
		tNbProjectile = 0;
		tVarReload = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//tir
		tvar += Time.deltaTime;
		if (tNbProjectile <= nbProjectile) {

			if (tvar >= interBullet) {
				tvar = 0;
				if (Input.GetKey (KeyCode.A)) {//touche à appuyer pour tirer
					tNbProjectile ++;
					GameObject test = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
					test.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * bulletSpeed);
				}
			}

		}

		//rechargement

		else {
			tVarReload += Time.deltaTime;
			if(tVarReload>timeReload){
				tVarReload = 0;
				tNbProjectile = 0;
			}

		}

	}





}
