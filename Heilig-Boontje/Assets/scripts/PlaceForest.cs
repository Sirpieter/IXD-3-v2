using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForest : MonoBehaviour
{
    private TreeManager treeManager;
    // Start is called before the first frame update
    void Start()
    {
        treeManager = FindObjectOfType<TreeManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        treeManager.PlaceForestInParent();
    }
}
