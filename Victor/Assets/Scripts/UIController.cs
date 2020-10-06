using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Shooting shooting;
    public GameObject InventoryUI;

    public static bool GameInventory = false;

    private int point = 0;
    private int exp = 0;
    private int min = 1;
    private int max = 10;
    private float range = 1.5f;
    private int speed = 3;
    private int size = 4;
    private int damage = 3;
    private float cost = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (GameInventory)
            {
                HideInventory();
            }
            else
            {
                ShowInventory();
            }
        }
    }

    public bool getInventoryState()
    {
        return GameInventory;
    }

    public void HideInventory()
    {
        InventoryUI.SetActive(false);
        Time.timeScale = 1f;
        GameInventory = false;
    }

    void ShowInventory()
    {
        InventoryUI.SetActive(true);
        Time.timeScale = 0f;
        GameInventory = true;
    }

    public void gainExp(int expGain)
    {
        Debug.Log("exp : " + exp + " | gain : " + expGain);
        exp += expGain;
        while (exp >= 10)
        {
            point++;
            exp -= 10;
            Debug.Log("point:" + point);
        }
    }

    public void removeRange()
    {
        if (range > 0.5)
        {
            point++;
            range -= 0.5f;
            shooting.setRange(range);
        }
    }
    public void addRange()
    {
        if (point > 0 && range < max)
        {
            point--;
            range += 0.5f;
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
        if (cost > 0.1)
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
