using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CasillaNormal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Casilla>().enabled)
        {
            int n = int.Parse(transform.GetChild(0).GetComponent<TextMeshPro>().text);

            if (other.GetComponent<Casilla>().isSuma())
                n += other.GetComponent<Casilla>().num();
            else n -= other.GetComponent<Casilla>().num();

            other.transform.GetComponent<Casilla>().enabled = false;
            Destroy(other.transform.GetChild(0).gameObject);

            transform.GetChild(0).GetComponent<TextMeshPro>().text = n.ToString();
        }

    }
}
