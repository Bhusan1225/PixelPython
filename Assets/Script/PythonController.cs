using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PythonController : MonoBehaviour
{

    // public float pythonSpeed = 3f;

    public float speed = 5f; // Continuous movement speed
    private int direction = 1; // Direction: 1 for right, -1 for left




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pythonMovementrRight();
        //controlledMovement();



        // Check for input to change direction
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move along the X-axis
        Vector3 position = transform.position;
        position.x += horizontalInput * speed * Time.deltaTime;
        transform.position = position;
    }
//void pythonMovementrRight()
//    {
//        transform.position += transform.right * pythonSpeed * Time.deltaTime; // Move in the X-axis based on rotation
//    }

//    void pythonMovementrLeft()
//    {
//        transform.position += -transform.right * pythonSpeed * Time.deltaTime; // Move in the X-axis based on rotation
//    }

    void controlledMovement()
    {

        //float zRotation = transform.eulerAngles.z;

        //// Check if the z-axis rotation is zero
        //bool isZAngleZero = Mathf.Approximately(zRotation, 0f);

        //// Check if the z-axis rotation is -90
        //bool isZAngleoneeighty = Mathf.Approximately(zRotation, 180f);



        //if (Input.GetKeyDown(KeyCode.W))
        //{

            
        //    Vector3 eulerRotation = transform.eulerAngles;
        //    eulerRotation.z = 90f;
        //    transform.eulerAngles = eulerRotation;


        //}

        //if (Input.GetKeyDown(KeyCode.S) && isZAngleZero == true || isZAngleoneeighty == true)
        //{


        //    Vector3 eulerRotation = transform.eulerAngles;
        //    eulerRotation.z = -90f;
        //    transform.eulerAngles = eulerRotation;


        //}
        //else if(Input.GetKeyDown(KeyCode.D) && isZAngleZero == false || isZAngleoneeighty == false)
        //{
        //    Vector3 eulerRotation = transform.eulerAngles;
        //    eulerRotation.z = 0f;
        //    transform.eulerAngles = eulerRotation;
        //}
        
        
        //if (Input.GetKeyDown(KeyCode.A) )
        //{
            
        //    Vector3 eulerRotation = transform.eulerAngles;
        //    eulerRotation.z = -180f;
        //    transform.eulerAngles = eulerRotation;
        //}




    }
}
