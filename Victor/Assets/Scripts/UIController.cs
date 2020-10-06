using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public Shooting shooting;
    public GameObject InventoryUI;

    public TextMeshProUGUI PointLabel;
    public TextMeshProUGUI RangeQuantity;
    public TextMeshProUGUI SpeedQuantity;
    public TextMeshProUGUI SizeQuantity;
    public TextMeshProUGUI CostQuantity;
    public TextMeshProUGUI DamageQuantity;

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

    // Pour gérer les valeurs de base
    void Start()
    {
        PointLabel.text = point + " Points";
        RangeQuantity.text = "" + range / 0.5f;
        SpeedQuantity.text = "" + speed;
        SizeQuantity.text = "" + size;
        CostQuantity.text = "" + (cost * 10f);
        DamageQuantity.text = "" + damage;
    }

    // Pour gérer la touche I
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
            PointLabel.text = point + " Points";
            RangeQuantity.text = "" + range / 0.5f;
        }
    }
    public void addRange()
    {
        if (point > 0 && range < max)
        {
            point--;
            range += 0.5f;
            shooting.setRange(range);
            PointLabel.text = point + " Points";
            RangeQuantity.text = "" + range / 0.5f;
        }
    }

    public void removeSize()
    {
        if (size > min)
        {
            point++;
            size--;
            shooting.setSize(size);
            PointLabel.text = point + " Points";
            SizeQuantity.text = "" + size;
        }
    }

    public void addSize()
    {
        if (point > 0 && size < max)
        {
            point--;
            size++;
            shooting.setSize(size);
            PointLabel.text = point + " Points";
            SizeQuantity.text = "" + size;
        }
    }

    public void removeSpeed()
    {
        if (speed > min)
        {
            point++;
            speed--;
            shooting.setSpeed(speed);
            PointLabel.text = point + " Points";
            SpeedQuantity.text = "" + speed;
        }
    }

    public void addSpeed()
    {
        if (point > 0 && speed < max)
        {
            point--;
            speed++;
            shooting.setSpeed(speed);
            PointLabel.text = point + " Points";
            SpeedQuantity.text = "" + speed;
        }
    }

    public void removeDamage()
    {
        if (damage > min)
        {
            point++;
            damage--;
            shooting.setDamage(damage);
            PointLabel.text = point + " Points";
            DamageQuantity.text = "" + damage;
        }
    }

    public void addDamage()
    {
        if (point > 0 && damage < max)
        {
            point--;
            damage++;
            shooting.setDamage(damage);
            PointLabel.text = point + " Points";
            DamageQuantity.text = "" + damage;
        }
    }

    public void removeCost()
    {
        if (point > 0 && cost > 0.1)
        {
            point--;
            cost -= 0.1f;
            shooting.setCost(cost);
            PointLabel.text = point + " Points";
            CostQuantity.text = "" + cost * 10f;
        }
    }

    public void addCost()
    {
        if (cost < max)
        {
            point++;
            cost += 0.1f;
            shooting.setCost(cost);
            PointLabel.text = point + " Points";
            CostQuantity.text = "" + cost * 10f;
        }
    }
}
