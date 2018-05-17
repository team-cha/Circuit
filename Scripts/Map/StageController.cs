using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public int number;
    public StageController[] preStages;
    public LineController outLine;

    void Start()
    {
        if (DataManager.instance.stages[number].Complete == true)
        {
            DataManager.instance.stages[number].Active = true;

            if (outLine != null)
            {
                LineOn();
            }
            ChangeColor1();
        }
        else
        {
            ActiveCheck();
        }
    }

    // 스테이지가 활성화 된 경우, 라인 활성화 
    public void LineOn()
    {
        outLine.ChangeColor();
    }

    public bool ActiveCheck()
    {
        for (int i = 0; i < preStages.Length; i++)
        {
            if (DataManager.instance.stages[preStages[i].number].Complete == false)
            {
                DataManager.instance.stages[number].Active = false;
                return false;
            }
        }
        ChangeColor2();
        DataManager.instance.stages[number].Active = true;
        return true;
    }

    public void ChangeColor1()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void ChangeColor2()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }


}
