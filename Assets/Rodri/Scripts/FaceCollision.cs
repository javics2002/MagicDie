using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FaceCollision : MonoBehaviour
{

    private float height= 1.7f;

    public Gradient color;
    TextMeshPro tm;
    Casilla cas;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Casilla>() != null && other.GetComponent<Casilla>().enabled)
        {
            int n = int.Parse(transform.GetChild(0).GetComponent<TextMeshPro>().text);

            StartCoroutine(suma(n, other.gameObject, .25f, .5f));

        }
    }
    private void OnTriggerStay(Collider other)
    {
        Goal goal = other.GetComponent<Goal>();
        if(goal != null && goal.enabled && !goal.getWon())
        {
            TextMeshPro tm = transform.GetChild(0).GetComponent<TextMeshPro>();
            if (tm.gameObject.activeSelf)
            {
                int n = int.Parse(tm.text);

                if (n == goal.getNumber()) // Win
                {
                    goal.setWon(true);
                    GetComponentInParent<CubeMovement>().setWon(true);
                }
            }
        }
    }


    IEnumerator suma(int n, GameObject casilla,float time,float time2)
    {
        yield return new WaitForSeconds(time);

        tm = transform.GetChild(0).GetComponent<TextMeshPro>();
        cas = casilla.GetComponent<Casilla>();

        if (cas.isSuma())
        {
            n += cas.num();
            tm.text = "+" + cas.num();
            tm.color = color.Evaluate(.5f + cas.num() / 6f);
        }
        else
        {
            n -= cas.num();
            tm.text = "-" + cas.num();
            tm.color = color.Evaluate(.5f - cas.num() / 6f);
        }

        tm.fontSize = 4f;


        cas.enabled = false;

        Destroy(casilla.transform.GetChild(0).gameObject);


        yield return new WaitForSeconds(time2);

        tm.text = n.ToString();
        tm.fontSize = 6;
        tm.color = Color.black;


    }
}
