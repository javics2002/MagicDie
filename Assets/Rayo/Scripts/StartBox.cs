using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBox : MonoBehaviour
{
    [SerializeField]
    public bool starting;
    [SerializeField]
    private float spawnSpeed = 2.3f;
    [SerializeField]
    private float finalPlatformHeight = 0.26f;
    [SerializeField]
    private GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        starting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (starting)
        {
            transform.Translate(new Vector3(0, spawnSpeed * Time.deltaTime, 0));
            cube.transform.Translate(new Vector3(0, spawnSpeed * Time.deltaTime, 0));

            if (transform.position.y >= finalPlatformHeight)
            {
                starting = false;
            }
        }
    }

    public bool isStarting()
    {
        return starting;
    }
}
