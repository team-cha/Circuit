using System.Collections;
using UnityEngine;

public class PlayerMissile : Missile
{
	void Awake()
    {
        shootDelay = 1f;
    }

	void Start()
	{
		StartCoroutine(Fire());
	}

	void OnEnable()
	{
		StartCoroutine(Fire());
	}
	
	public IEnumerator Fire()
    {
        yield return new WaitForSeconds(shootDelay);
        while (true)
        {
            CreateFromPoolAction(transform.position, transform.rotation);

            yield return new WaitForSeconds(shootDelay);
        }
    }
}
