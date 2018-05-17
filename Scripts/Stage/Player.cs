using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int hp;

	public float moveSpeed; // 이동 스피드
	public float rotateSpeed; // 회전 스피드

	Vector2 startPos;
	Vector2 direction;

	Vector3 move;
	float moveMagnitude;
	
	GameObject character;

	void Awake()
	{
		hp = 3;
		moveSpeed = 8f;
		rotateSpeed = 10f;

		character = GameObject.Find("Character");
	}

	void Update()
	{
#if UNITY_EDITOR
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		move.Set(h, 0, v);
		if(h != 0 || v != 0)
		{
			ObjectRotation(move);
			MovePosition(move);
		}
#elif UNITY_ANDROID
		// 터치 정보 받아오기
		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			switch (touch.phase)
			{
				case TouchPhase.Began:
					startPos = touch.position;
					break;
				case TouchPhase.Moved:
					direction = touch.position - startPos;
					break;
				case TouchPhase.Ended:
					direction = Vector2.zero;
					break;
			}
		}

		float x = direction.x;
		float y = direction.y;

		if(direction.magnitude > MaxInputRange)
		{
			x /= direction.magnitude;
			y /= direction.magnitude;
		}
		else
		{
			x /= MaxInputRange;
			y /= MaxInputRange;
		}

		move.Set(x, 0, y);
		moveMagnitude = move.magnitude;
		// 터치 시 일정 범위 이상 움직여야 움직이도록 오차 범위 설정
		if(moveMagnitude > 0.02f)
		{
			ObjectRotation(move);
			MovePosition(move);
		}
#endif
	}

	// 입력받은 방향으로 이동
	void MovePosition(Vector3 move)
	{
		move = move * Time.deltaTime * moveSpeed;
		transform.position = move + transform.position;

		// 이동 범위 제한
		//transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinMoveRangeX, MaxMoveRangeX), 0f, Mathf.Clamp(transform.position.z, MinMoveRangeY, MaxMoveRangeY));
	}

	// 자식 객체인 Charater를 입력받은 방향으로 회전
	void ObjectRotation(Vector3 rot)
	{
		rot = rot.normalized;
		Quaternion q = Quaternion.LookRotation(rot);
        character.transform.rotation = Quaternion.Slerp(character.transform.rotation, q, rotateSpeed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision hit)
	{
		
	}
}
