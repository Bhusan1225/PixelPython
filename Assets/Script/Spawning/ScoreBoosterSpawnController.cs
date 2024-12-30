using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoosterSpawnController : MonoBehaviour
{
   
    public bool isScoreBoosterThere = false;

    public GameObject ScoreBooster;

    public Vector2 spawnAreaMin = new Vector2(24, -15);
    public Vector2 spawnAreaMax = new Vector2(18, 15);

    public Quaternion ScoreBoosterSpawnRotation = Quaternion.identity;


    // Update is called once per frame
    void Update()
    {

        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {

        yield return new WaitForSeconds(70f);


        spawnLoop();
    }

    public void spawnLoop()
    {


        while (isScoreBoosterThere == false)
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
        Instantiate(ScoreBooster, randomPosition, ScoreBoosterSpawnRotation);




        isScoreBoosterThere = true;
    }

    public void noScoreBoosterThere()
    {
        isScoreBoosterThere = false;
    }
}



