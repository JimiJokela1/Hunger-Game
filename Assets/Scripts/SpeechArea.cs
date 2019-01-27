using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechArea : MonoBehaviour
{    
	private static SpeechArea _instance;
	public static SpeechArea Instance
	{
		get
		{
			return _instance = _instance ?? FindObjectOfType<SpeechArea>();
		}
	}
	public Text speechText;

	public GameObject buttonObject;

	private string activeText;

	public bool IsTextShowing(string text)
	{
		return text == activeText;
	}

	private void Start()
	{
        HideText();
	}

	public void ShowText(string text)
	{
		speechText.text = text;
		buttonObject.SetActive(true);
		activeText = text;
	}

	public void HideText()
	{
		buttonObject.SetActive(false);
		activeText = "";
	}
}
