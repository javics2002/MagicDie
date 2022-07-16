using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowInformation : MonoBehaviour
{
    //This field gets serialized even though it is private
    //because it has the SerializeField attribute applied.
    [SerializeField]
    private GameObject cube;

    //This field gets serialized even though it is private
    //because it has the SerializeField attribute applied.
    [SerializeField]
    private Vector3 direction;

    private CubeMovement cubeMovement;
    private CasillaRotar casillaRotar;
    MeshRenderer meshRenderer;

    private void Start()
    {
        cubeMovement = cube.GetComponentInParent<CubeMovement>(); 
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnMouseDown()
    {
        if (cubeMovement && !cubeMovement.isMoving() && meshRenderer.enabled)
        {
            cube.GetComponent<CubeMovement>().MoveCube(direction);
        }
    }

    private void Update()
    {
        if(cubeMovement != null)
        {
            if (cubeMovement.getWon())
            {
                GetComponent<Renderer>().enabled = false;
            }
            else
            {
                GetComponent<Renderer>().enabled = !cubeMovement.isMoving() && !cubeMovement.isRotating();
            }
        }
    }

    private void OnMouseOver()
    {
        Color color = meshRenderer.material.color;
        color.a = 1;
        meshRenderer.material.color = color;
    }

    private void OnMouseExit()
    {
        Color color = meshRenderer.material.color;
        color.a = .6f;
        meshRenderer.material.color = color;
    }
}
