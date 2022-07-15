using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeMovement : MonoBehaviour
{
    //This field gets serialized even though it is private
    //because it has the SerializeField attribute applied.
    [SerializeField]
    private bool moving = false;

    //This field gets serialized even though it is private
    //because it has the SerializeField attribute applied.
    [SerializeField]
    private Vector3 newDirection;

    public float degrees = 90f;
    public float timespan = 1f;

    private float _rotated = 0;
    private Vector3 _rotationVector;

    private void Update()
    {
        if (moving)
        {
            transform.Translate(newDirection * (Time.deltaTime / timespan));


            _rotated += degrees * (Time.deltaTime / timespan);

            if (degrees > _rotated)
            {
                transform.GetChild(0).Rotate(_rotationVector * (Time.deltaTime / timespan),Space.World);
            }
            else
            {
                // reset
                _rotationVector = new Vector3();
                _rotated = 0;

                moving = false;
            }
                
        }
        
    }

    public void MoveCube(Vector3 direction)
    {
        // Position
        newDirection = direction;
        newDirection.Normalize();

        // Rotation
        _rotationVector = new Vector3(newDirection.z * degrees, 0, -newDirection.x * degrees);

        moving = true;
    }
}
