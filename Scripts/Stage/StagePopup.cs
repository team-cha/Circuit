using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePopup : MonoBehaviour
{
	public Button menuBtn;
    public Button restartBtn;

	void Awake()
	{
        menuBtn.GetComponent<Button>().onClick.AddListener(() => { Menu(); });
        restartBtn.GetComponent<Button>().onClick.AddListener(() => { Restart(); });

		this.gameObject.SetActive(false);
	}

	private void Menu()
	{
		Time.timeScale = 1;
		MySceneManager.instance.MyLoadScene("Map");
	}

	private void Restart()
	{
		Time.timeScale = 1;
		MySceneManager.instance.ReloadScene();
	}
}
