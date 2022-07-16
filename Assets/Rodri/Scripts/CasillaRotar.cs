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



    private void Update()
    {
        if (rotating && !player.GetComponentInParent<CubeMovement>().isMoving())
        {
            transform.Rotate(newDirection * Time.deltaTime* rotateSpeed);
            player.transform.Rotate(newDirection * Time.deltaTime * rotateSpeed,Space.World);
            if (transform.rotation.eulerAngles.y >= 89.9f)
            {
                rotating = false;
                transform.rotation = Quaternion.Euler(new Vector3(transform.localRotation.x,0,transform.localRotation.z));
                player.GetComponentInParent<CubeMovement>().changeRotating(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rotating = true;
            player.GetComponentInParent<CubeMovement>().changeRotating(true);
            newDirection.Normalize();
        }
    }
}
