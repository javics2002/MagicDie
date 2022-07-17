using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasTransition;

    [SerializeField]
    private ResetButton resetButton;
    [SerializeField]
    private Button button;

    [SerializeField]
    private string newSceneName;

    private bool exit = false;

    private void Update()
    {
        if (exit && canvasTransition.GetComponent<GDTFadeEffect>().isFinished())
        {
            exit = false;
            SceneManager.LoadScene(newSceneName);
        }
    }
    public void OnClick()
    {
        exit = true;
        resetButton.enabled = false;
        button.enabled = false;
        GetComponent<Button>().enabled = false;
        
        canvasTransition.GetComponent<GDTFadeEffect>().StartFadeIn(0f);
    }
}
