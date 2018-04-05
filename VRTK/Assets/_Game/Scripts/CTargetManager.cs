using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTargetManager : MonoBehaviour {

    #region SINGLETON PATTERN
    public static CTargetManager _instance = null;
    #endregion

    // targets
    [SerializeField]
    List<GameObject> _targets;

    private void Awake()
    {
        // SINGLETON check
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);
    }

    public GameObject GetRandomTarget()
    {
        return _targets[Random.Range(0, _targets.Count)];
    }
}
