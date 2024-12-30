using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldPowerUp : MonoBehaviour
{
    bool isShildTaken;

    private void Start()
    {
        StartCoroutine(DestroyShield(20f));
    }


    public PowerupEnum powerUpType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Python"))
        {

            ShieldSpawnController spawnShield = FindAnyObjectByType<ShieldSpawnController>();
            spawnShield.noShieldThere();

            Debug.Log(" U got one shild");
            collision.GetComponent<PythonController>().ActivatePowerUp(powerUpType);
            Destroy(gameObject); 

            

        }    
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
