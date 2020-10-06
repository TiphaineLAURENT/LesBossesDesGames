using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float maxRange = 30f;
    private float defRange = 9f;
    private float range;

    private float maxSpeed = 60f;
    private float defSpeed = 18f;
    private float speed;

    private float maxSize = 10f;
    private float defSize = 4f;
    private float size;

    private int maxDamage = 100;
    private int defDamage = 30;
    private int damage;

    private int maxCost = 100;
    private int defCost = 10;
    private int cost;

    private void Start()
    {
        range = defRange;
        speed = defSpeed;
        size = defSize;
        damage = defDamage;
        cost = defCost;
    }

    public void setRange(int range)
    {
        this.range = maxRange * range / 10;
    }

    public void setSpeed(int speed)
    {
        this.speed = maxSpeed * speed / 10;
    }

    public void setSize(int size)
    {
        this.size = maxSize * size / 10;
    }

    public void setDamage(int damage)
    {
        this.damage = maxDamage * damage / 10;
    }

    public void setCost(float cost)
    {
        this.cost = (int) (maxCost * cost / 10);
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
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            bullet.transform.localScale *= size;
            rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
        }
    }
}
