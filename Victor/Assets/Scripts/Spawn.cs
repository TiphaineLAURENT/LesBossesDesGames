using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject iceNpc;
    //public GameObject fireNpc;
    //public GameObject lightningNpc;

    private float period = 5f;
    private int spawnNb = 0;
    private int spawnScale = 1;
    private float scale = 0.3f;
    private Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawn");
    }

    IEnumerator spawn()
    {
        while (true)
        {
            var height = (2 * Camera.main.orthographicSize);
            var width = (height * Camera.main.aspect);

            Vector2 spawnPosition = new Vector2(width / 2, height / 2);
            Instantiate(iceNpc, spawnPosition, Quaternion.identity);
            spawnNb++;
            Debug.Log("scale : " + scale);
            if (spawnNb > spawnScale && period > 0.1)
            {
                period -= scale;
                spawnNb = 0;
                spawnScale++;
                Debug.Log("Period : " + period);
            }
            yield return new WaitForSeconds(period);
        }
    }
}
