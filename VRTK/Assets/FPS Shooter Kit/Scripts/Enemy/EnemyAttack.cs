using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CompleteProject;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    PlayerHealth playerHealth;                  // Reference to the player's health.
    public int Damage = 80;
	public EnemyHealth Enemyhealth;

    private void Start()
    {
        // Setting up the references.
        playerHealth = CTargetManager._instance.GetRandomTarget().GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter (Collider PlayerCollider)
	{
		if (PlayerCollider.tag.Equals ("Target") && Enemyhealth.health > 0) {
		
			//Health	playerHealth = PlayerCollider.gameObject.GetComponent<Health> ();
            //playerHealth.SetDamage (Damage);

            // ... damage the player.
                playerHealth.TakeDamage (Damage);

		}

	}



}
