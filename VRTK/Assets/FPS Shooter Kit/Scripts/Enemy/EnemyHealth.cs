using CompleteProject;
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

    // score for killing this monster
    [SerializeField]
    int _scoreValue;

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

        // destroy corpse
        StartCoroutine(DestroyEnemy());

        // Increase the score by the enemy's score value.
        ScoreManager.score += _scoreValue;
    }

    // to destroy the corpse after he die
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(_destroyDelay);
        Destroy(this.gameObject);
        yield return null;
    }
}
