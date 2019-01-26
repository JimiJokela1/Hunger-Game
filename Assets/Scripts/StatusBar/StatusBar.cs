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
    internal float currentValue;

    internal bool timerIsRunning;
    public bool enableDescription;
    public bool enableTestingButton;

    public GameObject description;
    public GameObject testButtonGo;

    public virtual void Start()
    {
        description.SetActive(enableDescription ? true : false);

        testButtonGo.SetActive(enableTestingButton ? true : false);

        if (sliderImg != null)
            sliderImg.color = barColor;

        currentValue = maxValue;            
        SetValue(currentValue, maxValue);
    }

    public virtual void Update()
    {
        if (!timerIsRunning)
            return;
        
        ChangeValue(changedValuePerFrame);
        SetValue(currentValue, maxValue);
    }

    /// <summary>
    /// Adds the passed value to the current value of the slider. To decrease the value pass negative number
    /// </summary>
    public virtual void ChangeValue(float changedAmount)
    {
        currentValue = Mathf.Clamp(currentValue, 0, maxValue);
        currentValue += changedAmount;
        SetValue(currentValue, maxValue);
    }

    public virtual void SetValue(float cur, float max)
    {
        float value = cur / max;

        //  Change the localscale on the x axis
        healthBar.localScale = new Vector3(value, healthBar.localScale.y, healthBar.localScale.z);
    }

}
