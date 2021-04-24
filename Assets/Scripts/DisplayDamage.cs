using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageDisplay;
    [SerializeField] float displayTime = 0.3f;
    // Start is called before the first frame update
    private void Start()
    {
        damageDisplay.enabled = false;
    }

    public void ShowDamage()
    {
        StartCoroutine(ShowSplatter());
        damageDisplay.enabled = true;
    }

    IEnumerator ShowSplatter()
    {
        damageDisplay.enabled = true;
        yield return new WaitForSeconds(displayTime);
        damageDisplay.enabled = false;
    }
}
