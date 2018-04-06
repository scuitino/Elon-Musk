using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
	public EnemyHealth Health;
	public EnemyAI enemyAI;

	public void  SetDamage (float bulletdamage)
	{
		enemyAI.Hited = true;
		Health.SetDamage (bulletdamage);
	}
}
