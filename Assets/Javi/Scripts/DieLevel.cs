using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieLevel : MonoBehaviour
{
    [SerializeField] int level;

    void OnMouseDown()
    {
        SceneManager.LoadScene("Nivel " + level);
    }
}
