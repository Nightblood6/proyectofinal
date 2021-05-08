using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
   
    public BossInfo boss;
    public Transform player;
    private Animator animator;
    public bool isInvulnerable = false;
    public HealthBar healthBar;



    void Start()
    {
        
        animator = GetComponent<Animator>();
        boss.currentHealth = boss.maxHealth;
        healthBar.MaxHealth(boss.maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        boss.currentHealth -= damage;
        healthBar.SetHealth(boss.currentHealth);

        if (boss.currentHealth <= 250) 
        {
            animator.SetBool("IsRage", true);
        }
        
        if (boss.currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        
        animator.SetBool("isDeath", true);
        Destroy(gameObject);
    }
        
    }


