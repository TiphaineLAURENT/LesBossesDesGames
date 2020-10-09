using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float maxRange = 60f;
    private float defRange = 9f;
    private float range;

    private float maxSize = 40f;
    private float defSize = 2f;
    private float size;

    private float maxSpeed = 120f;
    private float defSpeed = 12f;
    private float speed;

    private int maxDamage = 100;
    private int defDamage = 15;
    private int damage;

    private int maxCost = 100;
    private int defCost = 20;
    private int cost;

    private void Start()
    {
        range = defRange;
        speed = defSpeed;
        size = defSize;
        damage = defDamage;
        cost = defCost;
    }

    public void setRange(float range)
    {
        this.range = maxRange * range / 10;
    }

    public void setSize(float size)
    {
        this.size = maxSize * size / 10;
    }

    public void setSpeed(float speed)
    {
        this.speed = maxSpeed * speed / 10;
    }


    public void setDamage(float damage)
    {
        this.damage = (int) (maxDamage * damage / 10);
    }

    public void setCost(float cost)
    {
        this.cost = (int) (maxCost * cost / 10);
    }

    public void setStat(float range, float size, float speed, int damage, int cost)
    {
        this.range = range;
        this.size = size;
        this.speed = speed;
        this.damage = damage;
        this.cost = cost;
    }

    public void restore()
    {
        gameObject.GetComponent<Stats>().fullLife();
        gameObject.GetComponent<Stats>().fullMana();
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
        if (gameObject.GetComponent<Stats>().getMana() > cost &&
            !GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>().getInventoryState()) {
            gameObject.GetComponent<Stats>().removeMana(cost);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().range = range;
            bullet.GetComponent<Bullet>().size = size;
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.GetComponent<Bullet>().caster = gameObject;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            bullet.transform.localScale *= size;
            rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
        }
    }
}
