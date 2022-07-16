using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FaceCollision : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Casilla>() != null && other.GetComponent<Casilla>().enabled)
        {
            int n = int.Parse(transform.GetChild(0).GetComponent<TextMeshPro>().text);

            if (other.GetComponent<Casilla>().isSuma())
                n += other.GetComponent<Casilla>().num();
            else n -= other.GetComponent<Casilla>().num();

            other.transform.GetComponent<Casilla>().enabled = false;
            Destroy(other.transform.GetChild(0).gameObject);

            transform.GetChild(0).GetComponent<TextMeshPro>().text = n.ToString();
        }
        else if(other.GetComponent<Goal>() != null && other.GetComponent<Goal>().enabled)
        {
            int n = int.Parse(transform.GetChild(0).GetComponent<TextMeshPro>().text);

            if(n == other.GetComponent<Goal>().getNumber()) // Win
            {
                other.transform.GetComponent<Goal>().enabled = false;
                Destroy(other.transform.GetChild(0).gameObject);
            }
        }

    }
}
