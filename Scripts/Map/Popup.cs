using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Popup : MonoBehaviour
{
    private Stage stage;

    private CameraDrag cameraDrag;
    private RaycastTouch raycastTouch;

    public Button closeBtn;
    public Text code;
    public Image image;
    public Button startBtn;

    void Awake()
    {
        this.gameObject.SetActive(false);
        closeBtn.GetComponent<Button>().onClick.AddListener(() => { Close(); });
        startBtn.GetComponent<Button>().onClick.AddListener(() => { GameStart(stage.Name); });

        cameraDrag = GameObject.FindWithTag("MainCamera").GetComponent<CameraDrag>();
        raycastTouch = GameObject.Find("Map").GetComponent<RaycastTouch>();
    }

    public void OnUpdateItem(string name)
    {
        MapOff();
        startBtn.GetComponent<Button>().enabled = true;
        this.stage = DataManager.instance.GetStage(name);

        code.text = stage.Code;

        if (stage.Complete)
        {
            image.sprite = stage.Image;
        }
        else
        {
            image.sprite = stage.NoImage;
            if (!stage.Active)
            {
                startBtn.GetComponent<Button>().enabled = false;
            }
        }
    }

    private void GameStart(string name)
    {
        MySceneManager.instance.MyLoadScene(name);
    }

    private void Close()
    {
        MapOn();
        this.gameObject.SetActive(false);
    }

    private void MapOff()
    {
        cameraDrag.enabled = false;
        raycastTouch.enabled = false;
    }

    private void MapOn()
    {
        cameraDrag.enabled = true;
        raycastTouch.enabled = true;
    }
}
