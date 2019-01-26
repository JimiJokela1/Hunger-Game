using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Use BasicBar prefab for reference
/// </summary>
public class StatusBar : MonoBehaviour
{

    [SerializeField]
    private RectTransform healthBar;

    [SerializeField]
    private Color barColor;

    [SerializeField]
    private Image sliderImg;

    public float maxValue;
    public float changedValuePerFrame;
    private float currentValue;

    public bool timerIsRunning;
    public bool enableTestingButton;

    public GameObject testButtonGo;

    void Start()
    {
        testButtonGo.SetActive(enableTestingButton ? true : false);

        if (sliderImg != null)
            sliderImg.color = barColor;

        currentValue = maxValue;            
        SetValue(currentValue, maxValue);
    }

    private void Update()
    {
        if (!timerIsRunning)
            return;
        
        ChangeValue(changedValuePerFrame);
        SetValue(currentValue, maxValue);
    }

    /// <summary>
    /// Adds the passed value to the current value of the slider. To decrease the value pass negative number
    /// </summary>
    public void ChangeValue(float changedAmount)
    {
        currentValue = Mathf.Clamp(currentValue, 0, maxValue);
        currentValue += changedAmount;
        SetValue(currentValue, maxValue);
    }

    public void SetValue(float cur, float max)
    {
        
        float value = cur / max;
        //Mathf.Clamp(value, 0, 1);

        //if (value <= 0 || cur >= maxValue)
        //    return;

        //  Change the localscale on the x axis
        healthBar.localScale = new Vector3(value, healthBar.localScale.y, healthBar.localScale.z);

        


    }

}
