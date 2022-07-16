using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 axis;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis, speed * Time.deltaTime, Space.World);
    }
}
