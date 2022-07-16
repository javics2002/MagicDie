using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private int number;
    [SerializeField]
    private float speed = 2.5f;
    [SerializeField]
    private bool won = false;

    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private GameObject canvasTransition;


    // Start is called before the first frame update
    private void Start()
    {
        TextMeshPro textMeshPro = transform.GetChild(0).GetComponent<TextMeshPro>();
        textMeshPro.text = number.ToString();
    }

    private void Update()
    {
        if (won && !cube.GetComponent<CubeMovement>().isMoving())
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0), Space.World);
        }
    }
    public int getNumber()
    {
        return number;
    }

    public void setWon(bool newState)
    {
        won = newState;

        if (won)
        {
            canvasTransition.GetComponent<GDTFadeEffect>().StartAnimation();
        }
    }


}
