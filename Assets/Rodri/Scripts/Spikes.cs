using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.transform.GetChild(0).gameObject.SetActive(false);
        other.transform.GetChild(1).gameObject.SetActive(true);
    }
}
