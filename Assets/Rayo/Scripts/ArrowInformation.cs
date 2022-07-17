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
    MeshRenderer meshRenderer;
    bool triggered = false;

    private void Start()
    {
        cubeMovement = cube.GetComponentInParent<CubeMovement>(); 
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnMouseDown()
    {
        if (cubeMovement && meshRenderer.enabled)
        {
            cubeMovement.MoveCube(direction);
        }
    }

    private void LateUpdate()
    {
        if(cubeMovement != null)
        {
            if (cubeMovement.getWon())
            {
                meshRenderer.enabled = false;
            }
            else
            {
                meshRenderer.enabled = triggered && !cubeMovement.isMoving() && !cubeMovement.isRotating();
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

    public void ChangeTriggered(bool b)
    {
        triggered = b;
    }
}
