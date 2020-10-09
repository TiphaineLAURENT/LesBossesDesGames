using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject iceNpc;
    public GameObject fireNpc;
    public GameObject thunderNpc;

    private List<GameObject> list = new List<GameObject>();
    private float period = 5f;
    private int spawnNb = 0;
    private int spawnScale = 1;
    private float scale = 0.3f;
    private Transform pos;

    public void Start()
    {
        if (!FirstCombat.IsFirstCombat)
        {
            startSpawn(true, true, true);
        }
    }

    public void startSpawn(bool ice = false, bool fire = false, bool thunder = false)
    {
        if (ice) { list.Add(iceNpc); }
        if (fire) { list.Add(fireNpc); }
        if (thunder) { list.Add(thunderNpc); }
        if (list.Count > 0)
        {
            StartCoroutine("spawn");
        }
    }

    IEnumerator spawn()
    {
        while (true)
        {
            var height = (2 * Camera.main.orthographicSize);
            var width = (height * Camera.main.aspect);

            int x = Random.value > 0.5 ? -1 : 1;
            int y = Random.value > 0.5 ? -1 : 1;
            UnityEngine.Vector2 spawnPosition = new UnityEngine.Vector2(x * width / 2, y * height / 2);
            Instantiate(list[Random.Range(0, list.Count)], spawnPosition, UnityEngine.Quaternion.identity); ;
            spawnNb++;
            if (spawnNb > spawnScale && period > 0.1)
            {
                period -= scale;
                spawnNb = 0;
                spawnScale++;
            }
            yield return new WaitForSeconds(period);
        }
    }
}
