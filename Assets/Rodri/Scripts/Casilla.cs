using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Casilla : MonoBehaviour
{

    public bool suma;
    public int number;
    public Gradient color;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshPro textMeshPro = transform.GetChild(0).GetComponent<TextMeshPro>();

        if (suma)
        {
            textMeshPro.text = number.ToString();
            textMeshPro.color = color.Evaluate(.5f + number / 6f);
        }
        else
        {
            textMeshPro.text = "-" + number;
            textMeshPro.color = color.Evaluate(.5f - number / 6f);
        }
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
