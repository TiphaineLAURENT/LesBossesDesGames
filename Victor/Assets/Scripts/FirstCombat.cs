using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCombat : MonoBehaviour
{
    public static bool IsFirstCombat = true;

    private int TeamChoice;

    // Start is called before the first frame update
    void Start()
    {
        TeamChoice = FirstDialogManager.TeamChoice;

        if (TeamChoice == 0)
        {
            GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawn>().startSpawn(false, true, true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>().setStat(40f, 1f, 100f, 10, 10);
        }
        else if (TeamChoice == 1)
        {
            GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawn>().startSpawn(true, false, true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>().setStat(5f, 5f, 10f, 20, 5);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawn>().startSpawn(true, true, false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>().setStat(20f, 10f, 5f, 100, 80);
        }
    }
}
