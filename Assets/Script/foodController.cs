using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodController : MonoBehaviour
{
   //internal foodSpawnManager spawnManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PythonController>() != null)
        {
            PythonController pythonController = collision.gameObject.GetComponent<PythonController>(); 
            Debug.Log("I am python,I will eat you.");
            pythonController.appleEaten();
            Destroy(gameObject);
        }
    }
    

  
}
