using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private int life = 100;
    private int mana = 100;

    private float period = 1f;

    private void Start()
    {
        StartCoroutine("DoCheck");
    }

    void Update()
    {
        if (life <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

    public void removeLife(int damage)
    {
        Debug.Log("Damage : " + damage);
        life -= damage;
        Debug.Log("Life : " + life);
    }

    public int getLife()
    {
        return life;
    }

    public void removeMana(int cost)
    {
        mana -= cost;
    }

    public int getMana()
    {
        return mana;
    }

    IEnumerator DoCheck()
    {
        while (true)
        {
            life += 5;
            if (life > 100)
                life = 100;
            mana += 3;
            if (mana > 100)
                mana = 100;
            yield return new WaitForSeconds(period);
        }
    }
}
