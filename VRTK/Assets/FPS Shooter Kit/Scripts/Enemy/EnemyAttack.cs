using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CompleteProject;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    CTarget _targetScript;                  // Reference to the targetScript.
    public int Damage = 80;
	public EnemyHealth Enemyhealth;

    private void Start()
    {
        // Setting up the references.
        _targetScript = CTargetManager._instance.GetRandomTarget().GetComponent<CTarget>();
    }

    void OnTriggerEnter (Collider tTargetCollider)
	{
		if (tTargetCollider.tag.Equals ("Target") && Enemyhealth._health > 0)
        {		
            // ... damage the player.
            PlayerHealth._instance.TakeDamage(Damage);
		}
	}
}
