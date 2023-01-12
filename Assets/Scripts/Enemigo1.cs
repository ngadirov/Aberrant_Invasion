using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] float speed;
	[SerializeField] int health = 2;
	[SerializeField] int damage = 5;
	GameObject targetGameObject;
	MC_Controller targetMC;

	Rigidbody2D rigidbody2d;

	private void Awake()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		targetGameObject = target.gameObject;
	}

	private void FixedUpdate()
	{
		Vector2 direction = (target.position - transform.position).normalized;
		rigidbody2d.velocity = direction * speed;
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject == targetGameObject)
		{
			Attack();
		}
	}

	private void Attack()
	{
		if(targetMC == null)
		{
			targetMC = targetGameObject.GetComponent<MC_Controller>();
		}
		targetMC.TakeDamage(damage);
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health < 1)
		{
			Destroy(gameObject);
		}
	}
}
