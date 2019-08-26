using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesAppearAndDestroyAtPosition : MonoBehaviour
{
    public Transform player;
    public GameObject[] choiceGameObjects;
    private Vector3 inPosition;
    private Vector3 outPosition;
    public bool isInArea;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < choiceGameObjects.Length; i++) {
            if (choiceGameObjects[i].activeInHierarchy && choiceGameObjects[i] != null) {
                choiceGameObjects[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!isInArea) {
            for (int i = 0; i < choiceGameObjects.Length; i++) {
                if (choiceGameObjects[i].activeInHierarchy && choiceGameObjects[i] != null) {
                    choiceGameObjects[i].SetActive(false);
                }
            }
        }

        if (!isInArea && Vector3.Distance(outPosition, transform.forward + transform.position) < Vector3.Distance(inPosition, transform.forward + transform.position)) {
            for (int i = 0; i < choiceGameObjects.Length; i++) {
                if (choiceGameObjects[i] != null)
                    Destroy(choiceGameObjects[i]);
                    Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform == player) {
            isInArea = true;
            inPosition = other.transform.position;
            for (int i = 0; i < choiceGameObjects.Length; i++) {
                if (!choiceGameObjects[i].activeInHierarchy && choiceGameObjects[i] != null) {
                    choiceGameObjects[i].SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform == player) {
            isInArea = false;
            outPosition = other.transform.position;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Debug.DrawLine(transform.position, transform.position + transform.forward);
    }
}
