using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barometer : MonoBehaviour
{
    [Header("Pressure(%)")]
    [SerializeField] private float maxPressure = 120f;
    [SerializeField] private float currentPressure = 50f;
    [Header("Threshold")]
    [SerializeField] private float threshold1 = 25f;
    [SerializeField] private float threshold2 = 50f;
    [SerializeField] private float threshold3 = 75f;
    [SerializeField] private float threshold4 = 100f;
    [Header("UI")]
    [SerializeField] private Image barometerFillImage;
    [SerializeField] private TMPro.TextMeshProUGUI barometerText;
    [Header("Animation")]
    //[SerializeField] private Gradient barometerGradient;
    [SerializeField] private float smoothSpeed = 10f;
    [Header("Debug")]
    [SerializeField] private bool setTargetPressureAtStart = true;
    [SerializeField] private float targetPressure=100f;
    // Start is called before the first frame update
    void Start()
    {
        if(barometerFillImage == null)
            barometerFillImage=GetComponent<Image>();
        if(barometerText == null)
            barometerText=GetComponentInChildren<TMPro.TextMeshProUGUI>();
        if(setTargetPressureAtStart==true)
            targetPressure = currentPressure;
        UpdateBarometer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(currentPressure - targetPressure) > 0.01f)
        {
            currentPressure=Mathf.Lerp(currentPressure, targetPressure, smoothSpeed*Time.deltaTime);
            UpdateBarometer();
        }
    }
    void UpdateBarometer()
    {
        if (barometerFillImage != null)
        {
            barometerFillImage.fillAmount = currentPressure / maxPressure;
            if (currentPressure < threshold1)
                barometerFillImage.color = Color.white;
            else if (currentPressure < threshold2)
                barometerFillImage.color = Color.green;
            else if (currentPressure < threshold3)
                barometerFillImage.color = Color.yellow;
            else if (currentPressure < threshold4)
                barometerFillImage.color = Color.red;
            else
                barometerFillImage.color = Color.red;
        }
        if(barometerText != null)
        {
            barometerText.text = Mathf.CeilToInt(currentPressure).ToString();
        }
    }
}
