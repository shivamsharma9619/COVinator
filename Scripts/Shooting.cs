using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Resolvers;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject reloadBut;
    public TextMeshProUGUI bullets;
    public TextMeshProUGUI maggs;
    int bulletCounter;
    public AudioSource ShootSound;
    public int magCounter;

    public float bulletForce = 20f;

    private void Start()
    {
        bulletCounter = 10;
        magCounter = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletCounter > 0)
            {
                Shoot();
            }
        }

        if (bulletCounter == 0)
        {
            reloadBut.SetActive(true);
        }
        else
        {
            reloadBut.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (magCounter > 0)
            {
                if (bulletCounter == 0)
                {
                    Reload();
                }
            }
        }

        bullets.text = bulletCounter.ToString();
        maggs.text = magCounter.ToString();
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bulletCounter -= 1;
        ShootSound.Play();
    }

    void Reload()
    {
        bulletCounter = 10;
        magCounter -= 10;
    }
}
