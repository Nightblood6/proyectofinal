using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private int damage = 10;
    public Rigidbody rb;
    public CombatController player;
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 2f);
    }

    public void OnTriggerEnter(Collider hitInfo)
    {
        CombatController player = hitInfo.GetComponent<CombatController>();
        if (player != null) 
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
       
    }

}
