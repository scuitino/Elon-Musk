using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFire : MonoBehaviour {

    // The damage inflicted by fire.
    [SerializeField]
    public float _damage;

    void OnTriggerStay(Collider other)
    {
        EnemyDamage tEnemyDamage = other.GetComponent<EnemyDamage>();
        // If the EnemyHealth component exist...
        if(tEnemyDamage != null)
        {
            // the enemy take damage.
            tEnemyDamage.SetDamage(_damage);
        }
    }
}
