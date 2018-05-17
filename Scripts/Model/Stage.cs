using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stage
{
    [SerializeField]
    private string name;
    private bool complete = false; // 완료 여부
    private bool active = false; // 활성화 여부
    [SerializeField]
    private string code;
    [SerializeField]
    private Sprite noImage;
    [SerializeField]
    private Sprite image;

    public string Name
    {
        get
        {
            return name;
        }
    }

    public string Code
    {
        get
        {
            return code;
        }
    }

    public Sprite NoImage
    {
        get
        {
            return noImage;
        }
    }

    public Sprite Image
    {
        get
        {
            return image;
        }
    }

    public bool Complete
    {
        get
        {
            return complete;
        }
        set
        {
            complete = value;
        }
    }

    public bool Active
    {
        get
        {
            return active;
        }
        set
        {
            active = value;
        }
    }
    
}
