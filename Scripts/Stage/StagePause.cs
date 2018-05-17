using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StagePause : MonoBehaviour
{
	public GameObject popup;

    void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(() => { Pause(); });
    }

    private void Pause()
    {
		if(popup.gameObject.activeSelf)
        {
            Time.timeScale = 1;
			popup.gameObject.SetActive(false);
        }
		else
        {
            Time.timeScale = 0;
			popup.gameObject.SetActive(true);
        }
    }
}
