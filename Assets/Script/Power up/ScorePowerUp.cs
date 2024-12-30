using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePowerUp : MonoBehaviour
{
    public PowerupEnum powerUpType;
    public float SpawnDuration = 5f;

    bool isScoreboostertaken;

    private void Start()
    {
        StartCoroutine(DestroyScoreBooster(39f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Python"))
        {
            Debug.Log(" U got one scoreBooster");
            collision.GetComponent<PythonController>().ActivatePowerUp(powerUpType);


            gameObject.SetActive(false);
            Destroy(gameObject, 20);



        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Invoke(nameof(checkSpawnScoreBooster), SpawnDuration);//working perfectly

    }

    void checkSpawnScoreBooster()
    {
        ScoreBoosterSpawnController spawnScoreBoster = FindAnyObjectByType<ScoreBoosterSpawnController>();
        spawnScoreBoster.noScoreBoosterThere();
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
