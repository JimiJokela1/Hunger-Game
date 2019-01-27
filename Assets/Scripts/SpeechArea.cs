using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechArea : MonoBehaviour
{
	//private static SpeechArea _instance;
	//public static SpeechArea Instance
	//{
	//	get
	//	{
	//		return _instance = _instance ?? FindObjectOfType<SpeechArea>();
	//	}
	//}
	public Text speechText;
	public Image messageImage;

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
		if (messageImage != null)
		{
			messageImage.sprite = null;
			messageImage.color = Color.clear;
		}
	}

	public void ShowText(string text, Sprite sprite)
	{
		speechText.text = text;
		buttonObject.SetActive(true);
		activeText = text;
		if (messageImage != null)
		{
			messageImage.sprite = sprite;
			messageImage.color = Color.white;
		}
	}

	public void HideText()
	{
		buttonObject.SetActive(false);
		activeText = "";
		if (messageImage != null)
		{
			messageImage.sprite = null;
			messageImage.color = Color.clear;
		}
	}
}
