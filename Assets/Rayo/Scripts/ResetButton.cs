using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasTransition;

    private bool reset = false;

    private void Update()
    {
        if (reset && canvasTransition.GetComponent<GDTFadeEffect>().isFinished())
        {
            reset = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void OnClick()
    {
        reset = true;
        canvasTransition.GetComponent<GDTFadeEffect>().StartFadeIn(0f);
    }
}
