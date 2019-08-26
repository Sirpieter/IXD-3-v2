using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceAction : MonoBehaviour
{

    public float treeRemovePercentage = 2f;
    public float sojaPlantPercentage = 1f;
    private TreeManager treeManager;
    // Start is called before the first frame update
    void Start()
    {
        treeManager = FindObjectOfType<TreeManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        treeManager.RemoveTrees(treeRemovePercentage);
        treeManager.PlantSoja(sojaPlantPercentage);
    }
}
