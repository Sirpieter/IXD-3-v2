using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear_3 : MonoBehaviour
{     [SerializeField] private Image customImage;     [SerializeField] private Text customText; 
    void Start()
    {
        customImage.enabled = false;
        customText.enabled = false;
    }      void OnTriggerEnter(Collider other)     {         if (other.CompareTag("Player"))         {             customImage.enabled = true;         }          if (other.CompareTag("Player"))         {             customText.enabled = true;         }     }      void OnTriggerExit(Collider other)     {         if (other.CompareTag("Player"))         {             customImage.enabled = false;         }          if (other.CompareTag("Player"))         {             customText.enabled = false;         }     } }

