using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float hitPoints = 100f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }
    // create public method to reduce hitpoints by amount of damage
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        BroadcastMessage("OnDamageTaken");
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameObject.tag == "Zombie")
        {
            if (isDead) { return; }
            GetComponent<Animator>().SetTrigger("Die");
            isDead = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
