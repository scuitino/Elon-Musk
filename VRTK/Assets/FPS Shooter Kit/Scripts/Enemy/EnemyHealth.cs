using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

	public float _health = 100;
	public Collider[] _colliderList = new Collider[1];

	public void SetDamage (float damage)
	{
        Debug.Log(_health);
		_health -= damage;
	}

	public void DeactivateCollider ()
	{
		for (int i = 0; i < _colliderList.Length; i++) {
			_colliderList [i].enabled = false;			
		}
	}

    public void TakeDamage(int aDamage)
    {
        _health -= aDamage;
    }
}
