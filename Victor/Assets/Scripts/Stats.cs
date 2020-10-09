using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject manaBar;

    private UIController Exp;
    public int expGain = 1;
    public int maxLife = 100;
    private int life ;
    public int maxMana = 100;
    private int mana;

    private float period = 1f;

    private void Start()
    {
        life = maxLife;
        mana = maxMana;
        Exp = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>();

        if (gameObject.tag == "Player")
        {
            healthBar.GetComponent<UIBars>().SetMaxValue(maxLife);
            manaBar.GetComponent<UIBars>().SetMaxValue(maxMana);
        }

        StartCoroutine("DoCheck");
    }

    void Update()
    {
        if (gameObject.tag == "Player")
        {
            healthBar.GetComponent<UIBars>().SetValue(life);
            manaBar.GetComponent<UIBars>().SetValue(mana);
        }
 
        if (life <= 0)
        {
            if (gameObject.tag == "Player")
            {
                if (SceneManager.GetActiveScene().buildIndex != 4)
                {
                    FirstCombat.IsFirstCombat = false;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(4);
                }
            }
            else
            {
                Exp.gainExp(expGain);
                Destroy(gameObject);
            }
        }
    }

    public void removeLife(int damage)
    {
        life -= damage;
    }

    public int getLife()
    {
        return life;
    }
    public void fullLife()
    {
        life = maxLife;
    }

    public void removeMana(int cost)
    {
        mana -= cost;
    }

    public void fullMana()
    {
        mana = maxMana;
    }

    public int getMana()
    {
        return mana;
    }

    IEnumerator DoCheck()
    {
        while (true)
        {
            life += 3;
            if (life > maxLife)
                life = maxLife;
            mana += 3;
            if (mana > maxMana)
                mana = maxMana;
            yield return new WaitForSeconds(period);
        }
    }
}
