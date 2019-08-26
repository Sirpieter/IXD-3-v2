using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//singleton: only one class of this type is in the scene
public class TreeManager : MonoBehaviour
{
    private static TreeManager instance;

    public static TreeManager Instance { get { return instance; } }

    public int columns = 10;
    public int rows = 10;
    public float spacing = 2;

    private int startTreeAmount;
    public int currentTreeAmount;
    public int currentSojaAmount = 5;
    public GameObject tree;
    public GameObject trunk;
    public GameObject sojaPlant;
    public float wantedYRotation = 90f;
    private List<Quaternion> rotations;
    [HideInInspector]
    public List<string> answers;
    public Text answerSheet;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        startTreeAmount = columns * rows;
        rotations = new List<Quaternion>(startTreeAmount);
        for (int i = 0; i < startTreeAmount; i++)
        {
            rotations.Add(Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
        }
        currentTreeAmount = columns * rows;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //RemoveTrees(10);
            //PlantSoja(5);
            //UpdateTrees();

            //PlaceForestInParent();
        }

    }

    public void RemoveTrees(float treePercentage)
    {
        currentTreeAmount -= Mathf.RoundToInt(0.01f * treePercentage * startTreeAmount);
    }
    public void PlantSoja(float sojaPercentage)
    {
        currentSojaAmount += Mathf.RoundToInt(0.01f * sojaPercentage * startTreeAmount);
    }

    public void UpdateTrees()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        int treesPlaced = 0;
        int trunksPlaced = 0;
        for (int x = 0; x < columns; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                if (treesPlaced <= currentTreeAmount)
                {
                    Instantiate(tree, new Vector3(x * spacing, 0, z * spacing) + transform.position, rotations[x * z], transform);
                    treesPlaced += 1;
                }
                else if (trunksPlaced <= (startTreeAmount - currentTreeAmount - currentSojaAmount))
                {
                    Instantiate(trunk, new Vector3(x * spacing, 0, z * spacing) + transform.position, rotations[x * z], transform);
                    trunksPlaced += 1;
                }
                else
                {
                    Instantiate(sojaPlant, new Vector3(x * spacing, 0, z * spacing) + transform.position, rotations[x * z], transform);
                }
            }
        }
        transform.root.rotation = Quaternion.Euler(0, transform.eulerAngles.y + wantedYRotation, 0);

    }

    public void PlaceForestInParent()
    {
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        for (int x = 0; x < columns; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                Instantiate(tree, new Vector3(x * spacing, 0, z * spacing) + transform.position, rotations[x * z], transform);
            }
        }
        transform.root.rotation = Quaternion.Euler(0, transform.eulerAngles.y + wantedYRotation, 0);
    }


    public void UpdateAnswerSheet()
    {
        string answerSheetText = "";
        for (int i = 0; i < answers.Count; i++)
        {
            answerSheetText += i.ToString() + ". ";
            answerSheetText += answers[i];
            answerSheetText += "\n";
        }
        answerSheet.text = answerSheetText;
    }

}
