using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Shooting shooting;
    private int point = 0;
    private int exp = 0;
    private int min = 1;
    private int max = 10;
    private int range = 3;
    private int speed = 3;
    private int size = 4;
    private int damage = 3;
    private float cost = 1f;

    public void gainExp()
    {
        exp++;
        if (exp >= 10)
        {
            point++;
            exp -= 10;
            Debug.Log("point:" + point);
        }
    }

    public void removeRange()
    {
        if (range > min)
        {
            point++;
            range--;
            shooting.setRange(range);
        }
    }
    public void addRange()
    {
        if (point > 0 && range < max)
        {
            point--;
            range++;
            shooting.setRange(range);
        }
    }

    public void removeSize()
    {
        if (size > min)
        {
            point++;
            size--;
            shooting.setSize(size);
        }
    }

    public void addSize()
    {
        if (point > 0 && size < max)
        {
            point--;
            size++;
            shooting.setSize(size);
        }
    }

    public void removeSpeed()
    {
        if (speed > min)
        {
            point++;
            speed--;
            shooting.setSpeed(speed);
        }
    }

    public void addSpeed()
    {
        if (point > 0 && speed < max)
        {
            point--;
            speed++;
            shooting.setSpeed(speed);
        }
    }

    public void removeDamage()
    {
        if (damage > min)
        {
            point++;
            damage--;
            shooting.setDamage(damage);
        }
    }

    public void addDamage()
    {
        if (point > 0 && damage < max)
        {
            point--;
            damage++;
            shooting.setDamage(damage);
        }
    }

    public void removeCost()
    {
        if (cost > min)
        {
            point++;
            cost -= 0.1f;
            shooting.setCost(cost);
        }
    }

    public void addCost()
    {
        if (point > 0 && cost < max)
        {
            point--;
            cost += 0.1f;
            shooting.setCost(cost);
        }
    }
}
