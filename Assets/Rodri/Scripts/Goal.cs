using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private int number;
    [SerializeField]
    private Gradient color;
    // Start is called before the first frame update
    private void Start()
    {
        TextMeshPro textMeshPro = transform.GetChild(0).GetComponent<TextMeshPro>();
        textMeshPro.text = number.ToString();
    }
    public int getNumber()
    {
        return number;
    }
}
