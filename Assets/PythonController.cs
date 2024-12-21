using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PythonController : MonoBehaviour
{

    public float pythonSpeed = 3f;
    public float rotationAngle = 90f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pythonMovement();
        controlledMovement();
    }

    void pythonMovement()
    {
        Vector3 position = transform.position;
        position.x += pythonSpeed * Time.deltaTime;


        transform.position = position;
    }

    void controlledMovement()
    {

        if (Input.GetKey(KeyCode.W))
        {

            transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
        }
    }
}
