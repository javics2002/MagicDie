using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasTransition;

    [SerializeField]
    private ExitButton exitButton;
    [SerializeField]
    private Button button;

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
        exitButton.enabled = false;
        button.enabled = false;
        GetComponent<Button>().enabled = false;

        canvasTransition.GetComponent<GDTFadeEffect>().StartFadeIn(0f);
    }
}
