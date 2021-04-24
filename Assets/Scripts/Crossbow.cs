using UnityEngine;

namespace Nokobot.Assets.Crossbow
{
    public class Crossbow : MonoBehaviour
    {
        public GameObject arrowPrefab;
        public Transform arrowLocation;
        [SerializeField] Ammo ammoSlot;
        [SerializeField] GameObject hitEffect;
        [SerializeField] GameObject parentGameObject;

        public float shotPower = 100f;

        void Start()
        {
            parentGameObject = GameObject.FindWithTag("Spawn At Runtime");

            if (arrowLocation == null)
                arrowLocation = transform;
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // Shoot();
            }
        }

        // void Shoot()
        // {
        //     if (ammoSlot.GetCurrentAmmo() > 0)
        //     {
        //         GameObject arrow = Instantiate(arrowPrefab, arrowLocation.position, arrowLocation.rotation);
        //         arrow.transform.parent = parentGameObject.transform;
        //         arrow.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);
        //         ammoSlot.LowerAmmoAmount();
        //     }
        //     else
        //     {
        //         Debug.Log("Uh-oh wan outta awwows.");
        //     }
        // }
    }
}
