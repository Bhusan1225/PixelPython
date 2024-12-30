using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawnController : MonoBehaviour


{
    public bool isShieldThere = false;

    public GameObject Shield;

    public Vector2 spawnAreaMin = new Vector2(24, -15);
    public Vector2 spawnAreaMax = new Vector2(18, 15);

    public Quaternion ShieldSpawnRotation = Quaternion.identity;
    


    // Update is called once per frame
    void Update()
    {

        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {

        yield return new WaitForSeconds(40f);


        spawnLoop();
    }

    public void spawnLoop()        
    {


        while (isShieldThere == false)
        {


            spawnShield();

        }
    }

    public void spawnShield()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

        Debug.Log("Shield spawned");
        Instantiate(Shield, randomPosition, ShieldSpawnRotation);

        isShieldThere = true;
    }

    public void noShieldThere()
    {
        isShieldThere = false;
    }
}

