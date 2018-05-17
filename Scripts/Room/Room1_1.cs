using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room1_1 : Room
{
	void Awake()
	{
		timer = GameObject.Find("Timer").GetComponent<Text>();

		timeLeft = 5f;
		coroutine = Coroutine();
	}

	IEnumerator Coroutine()
	{
		while(timeLeft > 0)
		{
			timer.text = CountDown().ToString();

			yield return new WaitForFixedUpdate();
		}

		RoomManager.instance.Step++;
		StopCoroutine(coroutine);
	}
}
