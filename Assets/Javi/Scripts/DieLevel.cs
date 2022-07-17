using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieLevel : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] AudioSource source;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        source.Play();
        SceneManager.LoadScene("Nivel " + level);
    }

    private void OnMouseEnter()
    {
        if(animator != null)
            animator.SetBool("Selected", true);
    }

    private void OnMouseExit()
    {
        if (animator != null)
            animator.SetBool("Selected", false);
    }
}
