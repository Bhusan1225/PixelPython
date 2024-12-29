using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoisonTrigger : MonoBehaviour
{

    bool isPoisionEatenByPython;

    //public bool isShieldActiveP;

    private void OnEnable()
    {
        //isShieldActiveP = false;
    }

    private void Start()
    {
        StartCoroutine(DestroyApple(30f));
        //isShieldActiveP = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(isShieldActiveP == true)
        //{
            
        //    Debug.Log("Don't worry the shield is active");
        //    return;

        //}

        if(collision.gameObject.CompareTag("Python"))
        {
            PythonController pythonController = collision.gameObject.GetComponent<PythonController>();

            pythonController.strinking();

            PoisionSpawnController poisionSpawn = FindObjectOfType<PoisionSpawnController>();
            
            isPoisionEatenByPython = true;
            
            poisionSpawn.noPosionThere();

            //gameObject.SetActive(false);
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

