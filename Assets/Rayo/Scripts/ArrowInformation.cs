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

    private void Start()
    {
        cubeMovement = cube.GetComponentInParent<CubeMovement>();
    }
    private void OnMouseDown()
    {
        if (cubeMovement && !cubeMovement.isMoving())
        {
            cube.GetComponent<CubeMovement>().MoveCube(direction);
        }
       
    }

    private void Update()
    {
        if(cubeMovement != null)
        {
            GetComponent<Renderer>().enabled = !cubeMovement.isMoving();
        }
        
    }
}
