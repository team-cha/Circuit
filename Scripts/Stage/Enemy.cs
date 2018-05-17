using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    float speed;

    private Transform target;
    private float minDist;

    void Awake()
    {
        speed = 3f;
        target = GameObject.Find("Player").GetComponent<Transform>();

        minDist = 1f;
    }

    void FixedUpdate()
    {
        transform.LookAt(target);

		// 최소 거리, 필요 없으면 삭제
        if (Vector3.Distance(transform.position, target.position) >= minDist)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}