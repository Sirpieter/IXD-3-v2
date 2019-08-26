using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnTrigger : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip audioFile;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.clip = audioFile;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Play sound");
        audioSource.Play();
    }
}
