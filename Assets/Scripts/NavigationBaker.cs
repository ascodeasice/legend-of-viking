using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{
    NavMeshSurface[] surfaces;

    private void Start()
    {
        surfaces = GetComponentsInChildren<NavMeshSurface>();
    }

    public void updateNavMesh()
    {
        surfaces = GetComponentsInChildren<NavMeshSurface>();

        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }
}