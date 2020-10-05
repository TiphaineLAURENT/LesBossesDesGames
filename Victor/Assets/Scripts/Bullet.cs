using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    private GameObject player;

    [HideInInspector]
    public float range = 1f;
    [HideInInspector]
    public float size = 1f;
    [HideInInspector]
    public int damage = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector2.Distance(player.transform.position, gameObject.transform.position) >= range)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != gameObject.name)
        {
            collision.gameObject.GetComponent<Stats>().removeLife(damage);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            effect.transform.localScale *= size;
            Destroy(effect, 0.3f);
            Destroy(gameObject);
        }
    }
}
