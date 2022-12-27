using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack = 2.0f;
    float timer;

    [SerializeField] GameObject leftSlashObject;
    [SerializeField] GameObject rightSlashObject;

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
			}
            else
			{
                leftSlashObject.SetActive(true);
			}
        }
    }

}
