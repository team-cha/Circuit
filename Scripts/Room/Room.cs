using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public GameObject[] enemies;
    protected float timeLeft;
    protected Text timer;

    protected IEnumerator coroutine;

    void OnEnable()
    {
		StartCoroutine(coroutine);
    }

    protected float CountDown()
    {
        timeLeft -= Time.deltaTime;
        return Mathf.Round(timeLeft);
    }
}
