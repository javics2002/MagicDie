using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInformation : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;

    [SerializeField]
    private bool isTriggered = false;

    private void Update()
    {
        if (isTriggered)
        {
            arrow.gameObject.SetActive(true);
        }
        else
        {
            arrow.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        isTriggered = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        isTriggered = false;
    }
}
