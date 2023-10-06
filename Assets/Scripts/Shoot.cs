using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Shoot : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private Transform weapon;
    [SerializeField] private GameObject ammunition, shootingLight;
    [Header("Sounds")]
    [SerializeField] private AudioSource shootingSound, reloadSound;
    [Header("Vars")]
    [SerializeField] private int ammunitionAmount, totalAmmunition, maxAmmunitionInBackpack;
    [SerializeField] private float shootingLightDuration;
    [SerializeField] private bool isReloading = false;

    private void Start()
    {
        ammunitionAmount = 8;
        totalAmmunition = 50;
        maxAmmunitionInBackpack = 50;
        shootingLightDuration = 0.1f;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammunitionAmount > 0 && !isReloading && Time.timeScale == 1f)
        {
            Shooting();
        }
    }
    private void Shooting()
    {
        Instantiate(ammunition, weapon.position, weapon.rotation);
        StartCoroutine(ActivateShootingLight());
        shootingSound.Play();
        ammunitionAmount -= 1;
    }
    private IEnumerator ActivateShootingLight()
    {
        shootingLight.SetActive(true);
        yield return new WaitForSeconds(shootingLightDuration);
        shootingLight.SetActive(false);
    }
    public void Reload()
    {
        if (!isReloading && Time.timeScale == 1f && ammunitionAmount < 8 && totalAmmunition > 0)
        {
            int remainingAmmo = 8 - ammunitionAmount;
            int ammoToReload = Mathf.Min(remainingAmmo, totalAmmunition);

            ammunitionAmount += ammoToReload;
            totalAmmunition -= ammoToReload;
            isReloading = true;
            reloadSound.Play();
            StartCoroutine(CompleteReload());
        }
    }
    private IEnumerator CompleteReload()
    {
        yield return new WaitForSeconds(2f);
        isReloading = false;
    }
    public void PickAmmunition(int ammo)
    {
        int spaceLeftInBackpack = maxAmmunitionInBackpack - totalAmmunition;
        int ammoToAdd = Mathf.Min(ammo, spaceLeftInBackpack);
        totalAmmunition += ammoToAdd;
    }
}
