using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform weapon;

    [SerializeField] private GameObject ammunition;

    [SerializeField] private int ammunitionAmount;

    private Character character;

    private void Start()
    {
        ammunitionAmount = 30;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammunitionAmount>0 && Time.timeScale==1f)
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        Instantiate(ammunition, weapon.position, weapon.rotation);
        ammunitionAmount -= 1;
    }
}
