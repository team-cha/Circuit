using System.Collections;
using UnityEngine;

public class Projectile : Missile
{
	public Transform[] particle;
	[HideInInspector]
    public Vector3 impactNormal;

	private Rigidbody projectileRigidbody;
	private Collider projectileCollider;

	private int explosionNum;
	private int mainNum;

	void Awake()
	{
		projectileRigidbody = GetComponent<Rigidbody>();
		projectileCollider = GetComponent<Collider>();
		particle = GetComponentsInChildren<Transform>(true);

		for(int i = 0; i < particle.Length; i++)
		{
			if(particle[i].name == "Explosion")
				explosionNum = i;
			else if(particle[i].name == "Main")
				mainNum = i;
		}

		speed = 1000f;

	}

	void Start()
	{
		projectileRigidbody.AddForce(transform.forward * speed);
	}

	void FixedUpdate()
	{
		//projectileRigidbody.velocity = transform.forward * speed * Time.fixedDeltaTime;
	}

	// 활성화 시 호출
	void OnEnable()
	{
		StartCoroutine(DestroyProjectile(5f));
		
		// 폭발했을 경우 파티클을 다시 활성, 비활성화 상태로
		if(particle[mainNum].gameObject.activeInHierarchy == false)
			particle[mainNum].gameObject.SetActive(true);
		if(particle[explosionNum].gameObject.activeInHierarchy == true)
			particle[explosionNum].gameObject.SetActive(false);

		if(projectileCollider.enabled == false)
			projectileCollider.enabled = true;

		projectileRigidbody.constraints = RigidbodyConstraints.None;
	}

	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.CompareTag("Enemy"))
		{
			particle[mainNum].gameObject.SetActive(false);
			
			projectileCollider.enabled = false;

			projectileRigidbody.constraints = RigidbodyConstraints.FreezeAll;

			particle[explosionNum].gameObject.SetActive(true);
		}
	}

	// 생성되고 일정 시간이 흐르면 비활성화(코루틴)
    private IEnumerator DestroyProjectile(float aliveTime)
    {
		yield return new WaitForSeconds(aliveTime);

		ReturnToPoolAction(gameObject);
    }
}
