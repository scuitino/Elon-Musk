using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // enemy health
	public float _health = 100;

    // colliders to turn off when the enemy dies
	public Collider[] _colliderList = new Collider[1];

    // delay before destroy the enemy
    [SerializeField]
    float _destroyDelay;

    // damage the enemy
	public void SetDamage (float damage)
	{
		_health -= damage;
	}

    // deactivate colliders when die
	public void DeactivateCollider ()
	{
		for (int i = 0; i < _colliderList.Length; i++) {
			_colliderList [i].enabled = false;			
		}
        StartCoroutine(DestroyEnemy());
	}

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(_destroyDelay);
        Debug.Log("why mother fucker");
        Destroy(this.gameObject);
        yield return null;
    }
}
