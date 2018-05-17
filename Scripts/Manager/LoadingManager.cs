using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance = null;

    public float loadingTime = 0;

	public Text cmd;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

		this.gameObject.SetActive(false);
	}

    public void Loading(string loadingText)
    {
        this.gameObject.SetActive(true);
        loadingText += "\r\n";
        loadingTime = loadingText.Length * 0.1f + 0.3f;
        StartCoroutine(Typewriter(loadingText));
    }

    private IEnumerator Typewriter(string loadingText)
    {
        for(int i = 0; i < loadingText.Length; i++)
        {
            cmd.text += loadingText[i];
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.3f);

        this.gameObject.SetActive(false);
    }
}
