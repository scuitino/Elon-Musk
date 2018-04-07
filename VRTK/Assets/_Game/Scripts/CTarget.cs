using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTarget : MonoBehaviour {

    public void TakeDamage(int aAmount)
    {
        PlayerHealth._instance.TakeDamage(aAmount);
    }
}
