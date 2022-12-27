using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Controller : MonoBehaviour
{
    [SerializeField] public float speed = 10.0f;
    public int maxHealth = 100;
    int currentHealth;

    Rigidbody2D rigidbody2d;
    // animator = Getcomponent<Animator>();
    //Vector2 lookDirection = new Vector2(1, 0);
    public Vector2 position;
    public float lastHorizontaVector;
    public float lastVerticalVector;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;


    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

  //      if(position.x != 0)
		//{
  //          lastHorizontaVector = 
		//}

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.fixedDeltaTime;
        position.y = position.y + speed * vertical *  Time.fixedDeltaTime;

        rigidbody2d.MovePosition(position);

        if (position.x != 0)
		{
            lastHorizontaVector = position.x;
		}
        if(position.y != 0)
		{
            lastVerticalVector = position.y;
		}




        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
