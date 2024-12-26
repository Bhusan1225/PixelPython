using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionSpawnController : MonoBehaviour
{
    public bool isPoisonThere = false;

    public GameObject Poison;

    public Vector2 spawnAreaMin = new Vector2(24, -15);
    public Vector2 spawnAreaMax = new Vector2(18, 15);

    public Quaternion PoisonSpawnRotation = Quaternion.identity;


    // Update is called once per frame
    void Update()
    {

        spawnLoop();
    }

    public void spawnLoop()
    {


        while (isPoisonThere == false)
        {
            
            spawnPoison();

        }
    }

    public void spawnPoison()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

        Debug.Log("Poison spawned");
        Instantiate(Poison, randomPosition, PoisonSpawnRotation); 




        isPoisonThere = true;
    }

    public void noPosionThere()
    {
        isPoisonThere = false;
    }
}
