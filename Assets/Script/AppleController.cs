using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{

   bool isAppleEatenBySnake;
    private void Start()
    {
        StartCoroutine(DestroyApple(10f));
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PythonController>() != null)
        {
            PythonController pythonController = collision.gameObject.GetComponent<PythonController>(); 
            
            Debug.Log("I am python,I eat 1 apple.");
            pythonController.appleEaten();
            
            Debug.Log("I got 1 point.");
            pythonController.pointScored();

            Debug.Log("I body increased.");
            pythonController.Grow();

            isAppleEatenBySnake = true;
            Destroy(gameObject);
        }
    }

    //10 sec timmer for the apple to destroy Automatically...
    private IEnumerator DestroyApple(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Missed! Destroying the fruit.");

        PythonController pythonController = FindObjectOfType<PythonController>();
       
         if (!isActiveAndEnabled)
        {
            pythonController.appleEaten();
        }
        Destroy(this.gameObject);

    }

  
}
