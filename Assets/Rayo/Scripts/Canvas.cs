using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    [SerializeField]
    private float rainbowSpeed;
    [SerializeField]
    private bool randomize;

    [SerializeField]
    private float hue;
    [SerializeField]
    private float sat;
    [SerializeField]
    private float bri;

    [SerializeField]
    private float verticalSpeed;
    [SerializeField]
    private float maxHeight;
    [SerializeField]
    private float minHeight;

    private Image titleImage;
    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        titleImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        if (randomize)
        {
            hue = Random.Range(0f, 1f);
        }
        //titleImage.color = Color.HSVToRGB(hue, sat, bri);

        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //ColorUpdate();
        MovementUpdate();
    }

    private void ColorUpdate()
    {
        Color.RGBToHSV(titleImage.color, out hue, out sat, out bri);

        hue += Time.deltaTime * rainbowSpeed;
        if (hue >= 1f)
        {
            hue = 0f;
        }
        titleImage.color = Color.HSVToRGB(hue, sat, bri);
    }

    private void MovementUpdate()
    {
        titleImage.transform.Translate(new Vector3(0, verticalSpeed * Time.deltaTime * direction, 0));

        if(titleImage.transform.position.y >= maxHeight)
        {
            titleImage.transform.SetPositionAndRotation(new Vector3(titleImage.transform.position.x, maxHeight, titleImage.transform.position.z), titleImage.transform.rotation);
            direction = -1;
        }
        else if(titleImage.transform.position.y <= minHeight)
        {
            titleImage.transform.SetPositionAndRotation(new Vector3(titleImage.transform.position.x, minHeight, titleImage.transform.position.z), titleImage.transform.rotation);
            direction = 1;
        }
    }
}
