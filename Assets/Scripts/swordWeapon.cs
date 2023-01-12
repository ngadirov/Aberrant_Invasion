using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack = 2.0f;
    float timer;

    [SerializeField] GameObject leftSlashObject;
    [SerializeField] GameObject rightSlashObject;
    [SerializeField] Vector2 slashAttackSize = new Vector2(2f, 4f);
    [SerializeField] int swordDamage = 2;

    MC_Controller mcMove;

	private void Awake()
	{
        mcMove = GetComponentInParent<MC_Controller>();
	}

	void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Attack();
        }

        void Attack()
        {
            timer = timeToAttack;

            if (mcMove.lastHorizontaVector > 0)
			{
                rightSlashObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightSlashObject.transform.position, slashAttackSize, 0f);
                ApplyDamage(colliders);
			}
            else
			{
                leftSlashObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftSlashObject.transform.position, slashAttackSize, 0f);
                ApplyDamage(colliders);
            }
        }
    }

	private void ApplyDamage(Collider2D[] colliders)
	{
		for (int i = 0; i < colliders.Length; i++)
		{
            Enemigo1 enemigo1 = colliders[i].GetComponent<Enemigo1>();
            if (enemigo1 != null)
			{
                colliders[i].GetComponent<Enemigo1>().TakeDamage(swordDamage);
            }
		}
	}
}
