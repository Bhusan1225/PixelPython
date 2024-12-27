using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoisonTrigger : MonoBehaviour
{

    bool isPoisionEatenByPython;
    private void Start()
    {
        StartCoroutine(DestroyApple(30f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PythonController>() != null)
        {
            PythonController pythonController = collision.gameObject.GetComponent<PythonController>();

            pythonController.Shrink();

            PoisionSpawnController poisionSpawn = FindObjectOfType<PoisionSpawnController>();
            
            isPoisionEatenByPython = true;
            
            poisionSpawn.noPosionThere();
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyApple(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("You are smart. How you know this is poision?");

        PoisionSpawnController poisionSpawn = FindObjectOfType<PoisionSpawnController>();

        if (!isPoisionEatenByPython)
        {
            poisionSpawn.noPosionThere();
        }
        Destroy(this.gameObject);

    }


}

