using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ia : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public Transform target;

    private float moveSpeed = 8f;
    public int turnSpeed;

    public float range;
    public float size;
    public float speed;
    public int damage;
    public int cost;

    private float lastAttackTime;
    public float attackDelay;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, target.position);
        Vector2 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, turnSpeed * Time.deltaTime);
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.x > 0.05 && screenPoint.x < 1 && screenPoint.y > 0.05 && screenPoint.y < 1;
        
        if (onScreen && distToPlayer < range)
        {
            if (Time.time > lastAttackTime + attackDelay && gameObject.GetComponent<Stats>().getMana() > cost && !GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>().getInventoryState())
            {
                RaycastHit2D hit = Physics2D.Raycast(firepoint.position, firepoint.up, range);
                if (hit.transform == target)
                {
                    Shoot();
                    lastAttackTime = Time.time;
                }
            }
        } else
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        }
    }


    void Shoot()
    {
        gameObject.GetComponent<Stats>().removeMana(cost);
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Bullet>().range = range;
        bullet.GetComponent<Bullet>().size = size;
        bullet.GetComponent<Bullet>().damage = damage;
        bullet.GetComponent<Bullet>().caster = gameObject;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        bullet.transform.localScale *= size;
        rb.AddForce(firepoint.up * speed, ForceMode2D.Impulse);
    }
}
