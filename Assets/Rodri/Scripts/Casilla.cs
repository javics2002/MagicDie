using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Casilla : MonoBehaviour
{

    public bool suma;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        if (suma) transform.GetChild(0).GetComponent<TextMeshPro>().text = "+" + number;
        else transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + number;
    }

    public bool isSuma()
    {
        return suma;
    }
    public int num()
    {
        return number;
    }
}
