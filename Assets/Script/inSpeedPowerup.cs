using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inSpeedPowerup : MonoBehaviour
{
    public PowerupEnum powerUpType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Python"))
        {
            Debug.Log(" U got one Speedboost");
            collision.GetComponent<PythonController>().ActivatePowerUp(powerUpType);
            Destroy(gameObject);



        }
    }
}
