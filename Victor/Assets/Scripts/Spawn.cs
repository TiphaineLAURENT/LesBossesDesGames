using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject iceNpc;
    //public GameObject fireNpc;
    //public GameObject lightningNpc;

    private float period = 1f;
    private Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DoCheck");
    }

    IEnumerator DoCheck()
    {
        while (true)
        {
            float spawnY = Random.Range
                   (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(iceNpc, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(period);
        }
    }
}
