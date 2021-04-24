using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRadius : MonoBehaviour
{
    [SerializeField] [Range(0, 20)] float radius;
    [SerializeField] Color wireColor;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = wireColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
