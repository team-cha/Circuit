using UnityEngine;
using System.Collections;

public class RaycastTouch : MonoBehaviour
{
    public GameObject popup;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (DataManager.instance.StageContains(hit.transform.name))
                {
                    Popup(hit.transform.name);
                }
            }
        }
#elif UNITY_ANDROID
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (DataManager.instance.StageContains(hit.transform.name))
                {
                    Popup(hit.transform.name);
                }
            }
        }
#endif
    }

    private void Popup(string name)
    {
        popup.SetActive(true);

        var page = popup.GetComponent<Popup>();
        if (page != null)
            page.OnUpdateItem(name);
    }
}