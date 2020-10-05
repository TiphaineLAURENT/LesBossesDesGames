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

    private int defDamage = 10;
    private int damage = 10;

    private int defCost = 5;
    private int cost = 5;

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

    public void setDamage(int damage)
    {
        this.damage = defDamage + damage;
    }

    public void setCost(int cost)
    {
        this.cost = defCost + cost;
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
        if (gameObject.GetComponent<Stats>().getMana() > cost) {
            gameObject.GetComponent<Stats>().removeMana(cost);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().range = range;
            bullet.GetComponent<Bullet>().size = size;
            bullet.GetComponent<Bullet>().damage = damage;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            bullet.transform.localScale *= size;
            rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
        } else
        {
            Debug.Log("Not enought mana");
        }
    }
}
