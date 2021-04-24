using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    public AmmoType ammoType;
    Ammo ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = FindObjectOfType<Ammo>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int currentAmmo = ammo.GetCurrentAmmo(ammoType);
            int maxAmmo = ammo.GetMaxAmmo(ammoType);
            if (currentAmmo == maxAmmo) { return; }
            ammo.RaiseAmmoAmount(ammoType, ammoAmount);
            Debug.Log(ammoType + " Item Pickup");
            Destroy(gameObject);
        }
    }
}
