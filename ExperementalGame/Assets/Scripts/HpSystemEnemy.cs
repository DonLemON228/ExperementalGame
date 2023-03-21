using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HpSystemEnemy : MonoBehaviour
{
    public int maxHealth;
    public HealthBar healthBar;
    public float currentHealth;
    public Animator animator;
    public AudioSource damageSource;

    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void GetDamage(int _count)
    {

        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
        }
        else
        {
            //damageSource.PlayOneShot(deathSound);
            animator.SetTrigger("Damage");
            currentHealth -= _count;
            healthBar.SetBarValue(currentHealth, maxHealth);
        }
    }

    //public void GetFallDamage(int _count)
    //{
        //damageSource.PlayOneShot(deathSound);
        //currentHealth -= _count;
        //healthBar.SetBarValue(currentHealth, maxHealth);
    //}
}


