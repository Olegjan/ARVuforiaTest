using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SortLogic : MonoBehaviour {
    public GameObject[] parents;
    public GameObject[] cubes;

    public class myCubeSorter : IComparer
    {
        int IComparer.Compare(System.Object x, System.Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(((GameObject)x).name, ((GameObject)y).name));
        }
    }
    void Start()
    {
        parents = GameObject.FindGameObjectsWithTag("Parents");
        cubes = GameObject.FindGameObjectsWithTag("Player");
    }
    public void FindParents()
    {
        IComparer myComparer = new myCubeSorter();
        Array.Sort(cubes, myComparer);
        Array.Sort(parents, myComparer);

        for (int i = 0; i < parents.Length; i++)

            for (int j = 0; j < cubes.Length; j++)
            {
                if (parents[i].name == cubes[i].name)
                    cubes[i].transform.SetParent(parents[i].transform);
                cubes[i].transform.position = new Vector3(parents[i].transform.position.x, parents[i].transform.position.y, parents[i].transform.position.z);
            }
    }
}
