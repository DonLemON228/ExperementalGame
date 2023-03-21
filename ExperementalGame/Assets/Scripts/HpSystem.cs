using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSystem : MonoBehaviour
{
    public int maxHealth;
    public HealthBar healthBar;
    public float currentHealth;
    public Animator animator;
    public AudioSource damageSource;
    public ParticleSystem healParticle;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);
    }

    public void GetDamage(int _count)
    {
        //damageSource.PlayOneShot(deathSound);
        animator.SetTrigger("Damage");
        currentHealth -= _count;
        healthBar.SetBarValue(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
        }
    }

    public void Heal(int healCount)
    {
        currentHealth += healCount;
        healParticle.Play();

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
