using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float defRange = 15f;
    private float range = 15f;

    private float defSpeed= 20f;
    private float speed = 20f;

    private float defSize = 4f;
    private float size = 4f;

    public void setRange(float range)
    {
        this.range = defRange * range;
    }

    public void setSpeed(float speed)
    {
        this.speed = defSpeed * speed;
    }

    public void setSize(float size)
    {
        this.size = defSize * size;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !PauseMenu.GamePaused)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().range = range;
        bullet.GetComponent<Bullet>().size = size;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        bullet.transform.localScale *= size;
        rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
    }
}
