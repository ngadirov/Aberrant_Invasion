using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashDisable : MonoBehaviour
{
	[SerializeField] float timeToDisable = 0.6f;
	float timer;
	private void OnEnable()
	{
		timer = timeToDisable;

	}
	private void LateUpdate()
	{
		timer -= Time.deltaTime;
		if (timer < 0)
		{
			gameObject.SetActive(false);
		}
	}
}
