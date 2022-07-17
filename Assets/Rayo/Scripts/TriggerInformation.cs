using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInformation : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;

    ArrowInformation arrowInfo;

    private void Start()
    {
        arrowInfo = arrow.GetComponent<ArrowInformation>();
    }

    private void OnTriggerStay(Collider other)
    {
        arrowInfo.ChangeTriggered(true);
    }

    private void OnTriggerExit(Collider collision)
    {
        arrowInfo.ChangeTriggered(false);
    }
}
