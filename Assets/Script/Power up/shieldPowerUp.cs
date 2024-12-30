using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldPowerUp : MonoBehaviour
{
    bool isShildTaken;
    public float SpawnDuration = 5f;

    private void Start()
    {
        StartCoroutine(DestroyShield(20f));
    }


    public PowerupEnum powerUpType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Python"))
        {


            

            Debug.Log(" U got one shild");
            collision.GetComponent<PythonController>().ActivatePowerUp(powerUpType);

            gameObject.SetActive(false);
            Destroy(gameObject,10);

        

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Invoke(nameof(checkSpawnShield), SpawnDuration);//working

    }

    void checkSpawnShield()
    {
        ShieldSpawnController spawnShield = FindAnyObjectByType<ShieldSpawnController>();
        spawnShield.noShieldThere();
    }

    private IEnumerator DestroyShield ( float delay)
    {
        yield return new WaitForSeconds(delay);

        ShieldSpawnController spawnShield = FindAnyObjectByType<ShieldSpawnController>();
        if (!isShildTaken)
        {
            spawnShield.noShieldThere();
        }
        Destroy(gameObject);
    }
}
