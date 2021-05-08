using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{

    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public Animator animator;
    public GameObject bulletPrefab;
    
    
    public void Attack1() 
    {
        FindObjectOfType<AudioManager>().Play("LAtk1");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
    }

    public void  Attack2() 
    {
        FindObjectOfType<AudioManager>().Play("LAtk1");
        Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
        Instantiate(bulletPrefab, firePoint5.position, firePoint5.rotation);
    }

    public void RageAtk() 
    {
        animator.SetTrigger("RAtk1");
        //Attack1();
        //Attack2();
    }

    
    public void RandomState()
    {
        int randomState = Random.Range(0, 2);

        if (randomState == 0)
        {
            animator.SetTrigger("Atk1");
        }
        else if (randomState == 1)
        {
            animator.SetTrigger("Atk2");
        } 
    }
}
