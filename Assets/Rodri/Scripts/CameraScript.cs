using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField]
    private bool rotataAroundPlayer = false;
    private bool lookAtPlayer = false;

    [SerializeField]
    private float rotationSpeed = 5.0f;

    [Range(0.01f,1.0f)]
    public float SmoothFactor = 0.5f;

    private Vector3 camOffset;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (rotataAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

            camOffset = camTurnAngle * camOffset;

            
        }

        if(lookAtPlayer || rotataAroundPlayer)
            transform.LookAt(player);



        Vector3 newPos = player.position + camOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);


        if (Input.GetButton("Fire1"))
        {
            rotataAroundPlayer = true;
        }
        else
        {
            rotataAroundPlayer = false;
            transform.LookAt(player);
        }

    }
}
