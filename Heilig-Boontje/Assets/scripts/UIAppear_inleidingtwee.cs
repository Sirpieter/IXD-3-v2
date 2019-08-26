using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear_inleidingtwee : MonoBehaviour
{
    [SerializeField] private RawImage customRawImage;
    [SerializeField] private Text customText;


    void Start()
    {
        customRawImage.enabled = false;
        customText.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customRawImage.enabled = true;
        }

        if (other.CompareTag("Player"))
        {
            customText.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customRawImage.enabled = false;
        }

        if (other.CompareTag("Player"))
        {
            customText.enabled = false;
        }
    }
}

