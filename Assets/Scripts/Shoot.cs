using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform weapon;

    [SerializeField] private GameObject ammunition;

    [SerializeField] private int ammunitionAmount;

    [SerializeField] private int maxAmmunition;

    private Character character;

    private bool isReloading = false;

    private void Start()
    {
        maxAmmunition = 100;
        ammunitionAmount = 30;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammunitionAmount>0 && !isReloading && Time.timeScale==1f)
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        Instantiate(ammunition, weapon.position, weapon.rotation);
        ammunitionAmount -= 1;
    }

    /*public void Reload()
    {
        if (!isReloading && ammunitionAmount<maxAmmunition)
        {
            StartCoroutine(Reloading());
        }
    }

    IEnumerator Reloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(2.0f);
        ammunitionAmount = maxAmmunition;
        isReloading = false;
    }*/
}
