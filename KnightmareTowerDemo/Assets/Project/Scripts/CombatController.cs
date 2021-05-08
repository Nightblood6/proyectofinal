using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour
{

    
    [SerializeField] private float atkRange;
    [SerializeField] private int atkDamage;
    [SerializeField] private float atkRate;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    
    private float nextAtkTime = 0f;
   

    private Animator anim;
    public Transform atkPoint;
    public LayerMask enemyLayer;
    public HealthBar healthBar;
    public Canvas canvas;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);
    }


    void Update()
    {
        if (Time.time >= nextAtkTime)
        {
            if ((Input.GetKey(KeyCode.J)))
            {
                Attack();
                FindObjectOfType<AudioManager>().Play("SlashAtk");
                nextAtkTime = Time.time + 1f / atkRate;
            }
        }
   
    }

   
    public void Attack()
    {
        anim.SetTrigger("Attack");
        Collider[] hitEnemies = Physics.OverlapSphere(atkPoint.position, atkRange, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Golpe a " + enemy.name);
            enemy.GetComponent<Boss>().TakeDamage(atkDamage);
            
        }
    }

 
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        anim.SetTrigger("IsHurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        
        anim.SetBool("IsDeath", true);
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        canvas.GetComponentInChildren<DeadMenu>().Endgame();
        GetComponent<CharacterController>().enabled = false;
    }



    public void OnDrawGizmosSelected()
    {

        if (atkPoint == null)
            return;
        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
       
    }
}
