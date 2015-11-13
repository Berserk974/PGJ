using UnityEngine;
using System.Collections;

public class life : MonoBehaviour
{
	 
	public int hpMax;
	public int regenHp;   //nombres de hp regeneré a chaque ticks
	public float regenHpTick;   //nombre de seconde avant de recevoir le prochain soin
	public int nbHpLostByWater; //nombre d'HP perdu par contact avec l'eau
	public float loseHpTick;    //nombre de seconde avant la prochaine perte d'HP



	private int hp;//currentHP
	private bool safe; //le joueur subit des dégats?
	private bool alive;//le joueur est en vie?
	private bool inWater;//le joueur est il encore sous l'effet de l'eau?
	private float tVarWater;// var temporaire pour la gestion du temps pour l'eau
	private float tVarRegen;//var temporaire pour la gestion du temps poiur la regen
	private int compt;//compteur  de tick pour l'eau

	//get-set
	int getHp ()
	{
		return hp;
	}

	void setHp (int i)
	{
		hp = i;
	}


	//fonctions

	void Start ()
	{
		hp = hpMax;
		alive = true;
		tVarRegen = 0;
		tVarWater = 0;
	}

	void WaterDamage ()
	{
		tVarWater = 0f;
		compt = 0;
		inWater = true;
		safe = false;
	}

	void FireContact ()
	{
		inWater = false;
		safe = true;
	}

	public void HitWithDamages (int i)
	{
		hp -= i;
	}

	void Death ()
	{
		inWater = false;
		alive = false;
	}

	void Resurection ()
	{
		alive = true;
		hp = hpMax;
	}

	void Update ()
	{
		//mort quand 0 hp
		if (hp <= 0) {
			Death ();
		}








		//regenerationHp
		tVarRegen += Time.deltaTime;
		if(tVarRegen>=regenHpTick){
			tVarRegen = 0;
			if (hp < hpMax && safe == true) {
				hp += 5;
				if (hp >= hpMax) {
					hp = hpMax;
				}
			}
		}

		//Les états
		if (inWater && alive) {
			if (compt < nbHpLostByWater) { 
				tVarWater += Time.deltaTime;
				if (tVarWater >= loseHpTick) {
					tVarWater = 0;
					compt += 1;
					hp--;
				}
			}
			else { 
				safe = true;
				inWater = false;
			}
		}



		Debug.Log (hp);
		//regen



	}
	

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag=="water") {
			WaterDamage ();
		}

		if (col.gameObject.tag=="fire") {
			FireContact ();
		}

	}


}
