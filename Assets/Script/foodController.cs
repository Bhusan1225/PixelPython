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
            Debug.Log("I am python,I eat 1 apple.");
            pythonController.appleEaten();
            Debug.Log("I got 1 point.");
            pythonController.pointScored();
            Destroy(gameObject);
        }
    }
    

  
}
