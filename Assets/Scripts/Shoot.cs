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

    [SerializeField] private GameObject shootingLight;

    [SerializeField] private float shootingLightDuration = 0.1f;

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
            StartCoroutine(ActivateShootingLight());
        }
        
    }

    private void Shooting()
    {
        Instantiate(ammunition, weapon.position, weapon.rotation);
        ammunitionAmount -= 1;
    }

    private IEnumerator ActivateShootingLight()
    {
        shootingLight.SetActive(true);
        yield return new WaitForSeconds(shootingLightDuration);
        shootingLight.SetActive(false);
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
