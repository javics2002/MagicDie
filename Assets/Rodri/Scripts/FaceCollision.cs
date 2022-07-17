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

    [SerializeField]
    private ParticleSystem pS;
    [SerializeField]
    private AudioSource sfx1;
    [SerializeField]
    private AudioSource sfx2;
    [SerializeField]
    private AudioSource sfx3;
    [SerializeField]
    private AudioSource sfx4;
    [SerializeField]
    private AudioSource sfx5;
    [SerializeField]
    private AudioSource[] sfxNumber;

    Color originalTextColor;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Casilla>() != null && other.GetComponent<Casilla>().enabled)
        {
            int n = int.Parse(transform.GetChild(0).GetComponent<TextMeshPro>().text);

            StartCoroutine(suma(n, other.gameObject, .25f, .5f));

        }
        Goal goal = other.GetComponent<Goal>();
        if (goal != null && goal.enabled && !goal.getWon())
        {
            TextMeshPro tm = transform.GetChild(0).GetComponent<TextMeshPro>();
            if (tm.gameObject.activeSelf)
            {
                int n = int.Parse(tm.text);

                if (n == goal.getNumber()) // Win
                {
                    goal.setWon(true);
                    GetComponentInParent<CubeMovement>().setWon(true);
                    sfx3.Play();
                }
                else
                {
                    TextMeshPro otherTM = other.GetComponentInChildren<TextMeshPro>();
                    originalTextColor = otherTM.color;
                    otherTM.color = Color.red;
                    other.transform.GetChild(1).GetComponent<MeshRenderer>().material.SetFloat("_Fail", 1);
                    sfx2.Play();
                }
            }
            else
            {
                TextMeshPro otherTM = other.GetComponentInChildren<TextMeshPro>();
                originalTextColor = otherTM.color;
                otherTM.color = Color.red;
                other.transform.GetChild(1).GetComponent<MeshRenderer>().material.SetFloat("_Fail", 1);
                sfx2.Play();
            }
        }
        if (other.GetComponent<Spikes>())
        {
            sfx4.Play();
            pS.Play();
        }

        if (other.GetComponent<CasillaRotar>())
            sfx5.Play();

        if (other.GetComponent<StartBox>() && !other.GetComponent<StartBox>().isStarting()) sfx1.Play();
        else if(!other.GetComponent<StartBox>())sfx1.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        Goal goal = other.GetComponent<Goal>();
        if (goal != null && goal.enabled && !goal.getWon())
        {
            TextMeshPro tm = transform.GetChild(0).GetComponent<TextMeshPro>();
            if (tm.gameObject.activeSelf)
            {
                other.GetComponentInChildren<TextMeshPro>().color = originalTextColor;
                other.transform.GetChild(1).GetComponent<MeshRenderer>().material.SetFloat("_Fail", 0);
            }
        }
    }

        IEnumerator suma(int n, GameObject casilla,float time,float time2)
    {
        cas = casilla.GetComponent<Casilla>();
        sfxNumber[cas.isSuma() ? cas.num() + 3 : cas.num()].Play();
        
        yield return new WaitForSeconds(time);

        tm = transform.GetChild(0).GetComponent<TextMeshPro>();
        



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
