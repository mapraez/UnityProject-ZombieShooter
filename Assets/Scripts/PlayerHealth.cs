using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Debug.Log("You dEd son.");
            GetComponent<DeathHandler>().HandleDeath();
        }
        else
        {
            GetComponent<DisplayDamage>().ShowDamage();
            Debug.Log("Health Remaining: " + hitPoints);
        }
    }
}

