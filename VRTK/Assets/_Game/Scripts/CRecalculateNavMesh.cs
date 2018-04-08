using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CRecalculateNavMesh : MonoBehaviour {

    // NavMesh surfaces 
    NavMeshSurface _walkableNavMesh;

    private void Start()
    {
        _walkableNavMesh = this.GetComponent<NavMeshSurface>();
    }

    public void Recalculate()
    {
        _walkableNavMesh.BuildNavMesh();
    }

}
