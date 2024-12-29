using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePowerUp : MonoBehaviour
{
    public PowerupEnum powerUpType;


    bool isScoreboostertaken;
    private void Start()
    {
        StartCoroutine(DestroyScoreBooster(39f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Python"))
        {
            Debug.Log(" U got one scoreboost");
            collision.GetComponent<PythonController>().ActivatePowerUp(powerUpType);
            Destroy(gameObject);



        }
    }

    private IEnumerator DestroyScoreBooster(float delay)
    {
        yield return new WaitForSeconds(delay);

        ScoreBoosterSpawnController scoreBoosterSpawn = FindAnyObjectByType<ScoreBoosterSpawnController>();

        if (isScoreboostertaken)
        {
            scoreBoosterSpawn.noScoreBoosterThere();
        }
        Destroy(gameObject);
    }
}
