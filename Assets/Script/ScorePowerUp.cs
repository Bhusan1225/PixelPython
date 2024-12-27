using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePowerUp : MonoBehaviour
{
    public PowerupEnum powerUpType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Python"))
        {
            Debug.Log(" U got one scoreboost");

            Destroy(gameObject);



        }
    }
}
