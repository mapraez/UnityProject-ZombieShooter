using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    GameObject parentGameObject;
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] float timeBetweenShots = .5f;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] AudioClip firingSound;
    AudioSource audioSource;
    Transform player;

    bool canShoot = true;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        audioSource = player.GetComponentInChildren<AudioSource>();
        parentGameObject = GameObject.FindWithTag("Spawn At Runtime");
    }

    private void OnEnable()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            // Debug.Log("PressingFire");
            StartCoroutine(Shoot());

        }
    }

    private void DisplayAmmo()
    {
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayFiringSound();
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.LowerAmmoAmount(ammoType);
            Debug.Log("Current Ammo Amount: " + ammoSlot.GetCurrentAmmo(ammoType).ToString());
        }
        else
        {
            // click sound
            Debug.Log("Uh-oh wan outta buwwets.");
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayFiringSound()
    {
        audioSource.PlayOneShot(firingSound, 0.5f);
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
            Debug.Log($"Hit: {hit.transform.name} for {damage}.\n Remaining Health: {target.hitPoints}.");
        }
        else { return; }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject fx = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        fx.transform.parent = parentGameObject.transform;
    }
}
