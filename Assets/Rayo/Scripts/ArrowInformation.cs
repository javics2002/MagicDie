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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        cube.GetComponent<CubeMovement>().MoveCube(direction);
    }
}
