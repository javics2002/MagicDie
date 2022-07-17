using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputField : MonoBehaviour
{
    [SerializeField]
    private GameObject sliderX;
    [SerializeField]
    private GameObject sliderY;

    [SerializeField]
    private bool isInputX;

    private TMP_InputField inputField;

    private Slider _sliderX;
    private Slider _sliderY;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();

        _sliderX = sliderX.GetComponent<Slider>();
        _sliderY = sliderY.GetComponent<Slider>();
    }

    public void SetLevel()
    {
        if(inputField.text.Length == 0)
        {
            inputField.text = "0,05";

            if (isInputX)
                _sliderX.value = .05f;
            else
                _sliderY.value = .05f;
        }
        else
        {
            float inputValue = float.Parse(inputField.text);

            if (inputValue < 0.05f)
            {
                inputValue = 0.05f;
            }
            else if (inputValue > 5f)
            {
                inputValue = 5f;
            }

            inputValue = Mathf.Floor(inputValue * 100) / 100;

            inputField.text = inputValue.ToString();

            // Change Slider Value

            if (isInputX)
                _sliderX.value = inputValue;
            else
                _sliderY.value = inputValue;
        }

        GameManager.getInstance().UpdateCameraInfo(_sliderX.value, _sliderY.value);

       
    }

}
