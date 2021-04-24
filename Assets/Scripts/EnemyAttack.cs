using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 10f;
    AudioSource audioSource;
    [SerializeField] AudioClip zombieHit;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }

        Debug.Log("Hit Player");
        audioSource.PlayOneShot(zombieHit, 0.5f);
        // target.GetComponent<PlayerHealth>().TakeDamage(damage);
        target.TakeDamage(damage);


    }
}



