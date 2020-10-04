using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Shooting shooting;
    private int point = 0;
    private float min = 0.2f;
    private float speed = 1f;
    private float speedMax = 2f;
    private float speedMod = 0.1f;
    private float range = 1f;
    private float rangeMax = 2f;
    private float rangeMod = 0.1f;
    private float size = 1f;
    private float sizeMax = 2f;
    private float sizeMod = 0.1f;

    public void removeRange()
    {
        if (range > min)
        {
            point += 1;
            range -= rangeMod;
            shooting.setRange(range);
        }
    }
    public void addRange()
    {
        if (point > 0 && range < rangeMax)
        {
            point -= 1;
            range += rangeMod;
            shooting.setRange(range);
        }
    }

    public void removeSize()
    {
        if (size > min)
        {
            point += 1;
            size -= sizeMod;
            shooting.setSize(size);
        }
    }

    public void addSize()
    {
        if (point > 0 && size < sizeMax)
        {
            point -= 1;
            size += sizeMod;
            shooting.setSize(size);
        }
    }

    public void removeSpeed()
    {
        if (speed > min)
        {
            point += 1;
            speed -= speedMod;
            shooting.setSpeed(speed);
        }
    }

    public void addSpeed()
    {
        if (point > 0 && speed < speedMax)
        {
            point -= 1;
            speed += speedMod;
            shooting.setSpeed(speed);
        }
    }
}
