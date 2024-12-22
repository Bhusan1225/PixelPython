using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if  (collision.gameObject.GetComponent<PythonController>() != null)
        {
            Debug.Log("I am python,I will eat you.");
            Destroy(gameObject);
        }
    }
}
