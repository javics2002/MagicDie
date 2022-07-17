using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasillaRotar : MonoBehaviour
{

    public bool rotaIzquierda;
    public float rotateSpeed=3f;
    public Transform player;

    [SerializeField]
    private bool rotating = true;
    [SerializeField]
    private Vector3 newDirection;
    [SerializeField]
    private float degrees = 90f;
    [SerializeField]
    private float timespan = 0.5f;

    CubeMovement cube;

    private void Start()
    {
        cube = player.GetComponentInParent<CubeMovement>();
    }

    private void Update()
    {
        if (rotating && !cube.isMoving())
        {
            transform.Rotate(newDirection * Time.deltaTime* rotateSpeed, Space.World);
            player.transform.Rotate(newDirection * Time.deltaTime * rotateSpeed,Space.World);
            if (rotaIzquierda && transform.rotation.eulerAngles.y >= 89.9f)
            {
                rotating = false;
                transform.rotation = Quaternion.Euler(new Vector3(transform.localRotation.x, 0, transform.localRotation.z));
                cube.changeRotating(false);
            }
            else if (!rotaIzquierda && transform.rotation.eulerAngles.y <= 270.9f)
            {
                rotating = false;
                transform.rotation = Quaternion.Euler(new Vector3(transform.localRotation.x, 0, transform.localRotation.z));
                cube.changeRotating(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rotating = true;
            cube.changeRotating(true);
            newDirection.Normalize();
        }
    }
}
