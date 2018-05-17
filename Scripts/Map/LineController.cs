using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public int number;
	[HideInInspector]
    public MeshRenderer[] mesh;

    void Awake()
    {
        mesh = gameObject.GetComponentsInChildren<MeshRenderer>();
    }

    public void ChangeColor()
    {
        for (int i = 0; i < mesh.Length; i++)
        {
            mesh[i].material.color = Color.black;
        }
    }
}
