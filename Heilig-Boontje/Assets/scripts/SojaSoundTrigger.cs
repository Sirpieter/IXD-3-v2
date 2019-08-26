using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SojaSoundTrigger : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip didPlantSojaSound;
    public AudioClip didNotPlantSojaSound;
    private TreeManager treeManager;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        treeManager = FindObjectOfType<TreeManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (treeManager.currentSojaAmount > 0) {
            Debug.Log("Soja");
            audioSource.clip = didPlantSojaSound;
            audioSource.Play();
        }
        if (treeManager.currentSojaAmount <= 0) {
            Debug.Log(" No Soja");
            audioSource.clip = didNotPlantSojaSound;
            audioSource.Play();
        }
    }
}
