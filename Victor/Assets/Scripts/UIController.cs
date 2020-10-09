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
    private int lvl = 1;
    private int expNeeded = 1;
    private bool switchExp = true;
    private float range = 1.5f;
    private float rangeScale = 0.5f;
    private float size = 0.5f;
    private float sizeScale = 0.25f;
    private float speed = 1.0f;
    private float speedScale = 0.5f;
    private float damage = 1.5f;
    private float damageScale = 0.5f;
    private float cost = 1f;
    private float costScale = 0.1f;

    // Pour gérer les valeurs de base
    void Start()
    {
        PointLabel.text = point + " Points";
        RangeQuantity.text = "" + range / rangeScale;
        SizeQuantity.text = "" + size / sizeScale;
        SpeedQuantity.text = "" + speed / speedScale;
        DamageQuantity.text = "" + damage / damageScale;
        CostQuantity.text = "" + (int)(cost / costScale);
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
        exp += expGain;
        while (exp >= expNeeded)
        {
            point++;
            exp -= expNeeded;
            lvl++;
            if (switchExp)
            {
                expNeeded++;
            }
            switchExp = !switchExp;
            shooting.restore();
            PointLabel.text = point + " Points";
            Debug.Log("point:" + point);
        }
    }

    public void removeRange()
    {
        if (range > rangeScale)
        {
            point++;
            range -= rangeScale;
            shooting.setRange(range);
            PointLabel.text = point + " Points";
            RangeQuantity.text = "" + range / rangeScale;
        }
    }
    public void addRange()
    {
        if (point > 0 && range < max)
        {
            point--;
            range += rangeScale;
            shooting.setRange(range);
            PointLabel.text = point + " Points";
            RangeQuantity.text = "" + range / rangeScale;
        }
    }

    public void removeSize()
    {
        if (size > sizeScale)
        {
            point++;
            size -= sizeScale;
            shooting.setSize(size);
            PointLabel.text = point + " Points";
            SizeQuantity.text = "" + size / sizeScale;
        }
    }

    public void addSize()
    {
        if (point > 0 && size < max)
        {
            point--;
            size += sizeScale;
            shooting.setSize(size);
            PointLabel.text = point + " Points";
            SizeQuantity.text = "" + size / sizeScale;
        }
    }

    public void removeSpeed()
    {
        if (speed > speedScale)
        {
            point++;
            speed -= speedScale;
            shooting.setSpeed(speed);
            PointLabel.text = point + " Points";
            SpeedQuantity.text = "" + speed / speedScale;
        }
    }

    public void addSpeed()
    {
        if (point > 0 && speed < max)
        {
            point--;
            speed += speedScale;
            shooting.setSpeed(speed);
            PointLabel.text = point + " Points";
            SpeedQuantity.text = "" + speed / speedScale;
        }
    }

    public void removeDamage()
    {
        if (damage > damageScale)
        {
            point++;
            damage -= damageScale;
            shooting.setDamage(damage);
            PointLabel.text = point + " Points";
            DamageQuantity.text = "" + damage / damageScale;
        }
    }

    public void addDamage()
    {
        if (point > 0 && damage < max)
        {
            point--;
            damage += damageScale;
            shooting.setDamage(damage);
            PointLabel.text = point + " Points";
            DamageQuantity.text = "" + damage / damageScale;
        }
    }

    public void removeCost()
    {
        if (point > 0 && cost > costScale)
        {
            point--;
            cost -= costScale;
            shooting.setCost(cost);
            PointLabel.text = point + " Points";
            CostQuantity.text = "" + Mathf.RoundToInt(cost / costScale);
            Debug.Log("cost : " + cost);
            Debug.Log("costScale : " + costScale);
        }
    }

    public void addCost()
    {
        if (cost < max)
        {
            point++;
            cost += costScale;
            shooting.setCost(cost);
            PointLabel.text = point + " Points";
            CostQuantity.text = "" + Mathf.RoundToInt(cost / costScale);
        }
    }
}
