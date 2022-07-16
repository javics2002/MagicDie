using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInformation : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;

    [SerializeField]
    private bool isTriggered = false;

    MeshRenderer arrowRenderer;

    private void Start()
    {
        arrowRenderer = arrow.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        arrowRenderer.enabled = isTriggered;
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
