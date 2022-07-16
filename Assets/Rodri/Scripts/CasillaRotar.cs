using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasillaRotar : MonoBehaviour
{

    public bool rotaIzquierda;
    public float rotateSpeed=3f;
    public Transform player;

    [SerializeField]
    private bool moving = true;
    [SerializeField]
    private Vector3 newDirection;
    [SerializeField]
    private float degrees = 90f;
    [SerializeField]
    private float timespan = 0.5f;



    private void Update()
    {
        if (moving)
        {
            transform.Rotate(newDirection * Time.deltaTime* rotateSpeed);
            player.transform.Rotate(newDirection * Time.deltaTime * rotateSpeed,Space.World);
            if (transform.rotation.eulerAngles.y >= 89.9f)
            {
                moving = false;
                transform.rotation = Quaternion.Euler(new Vector3(transform.localRotation.x,0,transform.localRotation.z));
                player.GetComponentInParent<CubeMovement>().changeRotating(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hola");
            moving = true;
            player.GetComponentInParent<CubeMovement>().changeRotating(true);
            newDirection = new Vector3(0, 1, 0);
            newDirection.Normalize();
        }
    }
}
