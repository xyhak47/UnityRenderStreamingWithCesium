using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
	public static FadeInOut Instance = null;
	FadeInOut()
	{
		Instance = this;
	}

	private float fadeSpeed = 3f;
	private RawImage backImage;

	private Color taget_color;

	private bool need_fade = false;

	void Start()
	{
		backImage = this.GetComponent<RawImage>();
		backImage.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
	}

	void Update()
	{
		if(need_fade)
        {
			Fade();
		}
	}

	private void Fade()
    {
		backImage.color = Color.Lerp(backImage.color, taget_color, fadeSpeed * Time.deltaTime);
	}

	public void AutoFade(float wait, Action callback)
    {
		StartCoroutine(StartFade(wait, callback));
    }

	private IEnumerator StartFade(float wait, Action callback)
	{
		need_fade = true;
		//need_fade = false;

		if (need_fade)
        {
			taget_color = Color.black;
			yield return new WaitUntil(() => backImage.color.a >= 0.97f);
			backImage.color = Color.black;

			yield return new WaitForSeconds(wait);
			callback();

			taget_color = Color.clear;
			yield return new WaitUntil(() => backImage.color.a <= 0.03f);
			backImage.color = Color.clear;
		}
        else // directly call back
        {
			callback();
		}


		need_fade = false;
	}
}