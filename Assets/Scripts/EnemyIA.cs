using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour {
	public int range;
	public GameObject hero;
	public int attackPower;

	private int direction;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {

	if(Mathf.Abs(hero.transform.position.x - transform.position.x)<range)
		{
			if(hero.transform.position.x - transform.position.x>0){
				direction = 1;
			}
			else {direction = -1;}
			GetComponent<MoveScript>().Move(Vector2.right*direction);

		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag=="Player"){
			col.gameObject.GetComponent<life>().HitWithDamages(attackPower);
		}

	}
}
