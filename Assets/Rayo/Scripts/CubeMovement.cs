using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeMovement : MonoBehaviour
{
    //This field gets serialized even though it is private
    //because it has the SerializeField attribute applied.
    [SerializeField]
    private bool moving = false;
    [SerializeField]
    private bool won = false;
    [SerializeField]
    private Vector3 newDirection;
    [SerializeField]
    private float degrees = 90f;
    [SerializeField]
    private float timespan = 0.5f;
    [SerializeField]
    private float maxHeight = 0.707f;
    [SerializeField]
    private float finalHeight = 0.51f;
    [SerializeField]
    private float wonSpeed = 2.5f;

    private float _rotated = 0;
    private Vector3 _rotationVector;

    [SerializeField]
    private bool rotating = false;

    private void Update()
    {
        if (moving)
        {
            transform.Translate(newDirection * (Time.deltaTime / timespan));

            _rotated += degrees * (Time.deltaTime / timespan);

            if (degrees/2 > _rotated) // Sumo altura
            {
                transform.Translate(new Vector3(0, maxHeight * Time.deltaTime, 0), Space.World);
            }
            else // Resto altura
            {
                transform.Translate(new Vector3(0, -maxHeight * Time.deltaTime, 0), Space.World);
            }

            if (degrees > _rotated)
            {
                transform.GetChild(0).Rotate(_rotationVector * (Time.deltaTime / timespan), Space.World);
            }
            else
            {
                // reset
                _rotationVector = new Vector3();
                _rotated = 0;

                transform.SetPositionAndRotation(new Vector3(transform.position.x, finalHeight, transform.position.z), transform.rotation);

                Vector3 newAngles = transform.GetChild(0).localEulerAngles;
                newAngles /= 90f;

                newAngles.x = Mathf.Round(newAngles.x);
                newAngles.y = Mathf.Round(newAngles.y);
                newAngles.z = Mathf.Round(newAngles.z);

                newAngles *= 90f;

                transform.GetChild(0).rotation = Quaternion.Euler(newAngles);
                
                moving = false;
            }
                
        }

        if (won && !moving)
        {
            transform.Translate(new Vector3(0, wonSpeed * Time.deltaTime, 0), Space.World);
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

    public bool isMoving()
    {
        return moving;
    }

    public bool isRotating()
    {
        return rotating;
    }
    public void changeRotating(bool m)
    {
        rotating = m;
    }
    public void setWon(bool newState)
    {
        won = newState;
    }
    public bool getWon()
    {
        return won;
    }
}
