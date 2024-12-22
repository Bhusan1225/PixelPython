using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PythonController : MonoBehaviour
{

    public float pythonSpeed = 1f;
    Vector3 currentDirection = Vector3.up;



   




    // Start is called before the first frame update
    void Start()
    {

    }

        void Update()
    {
        // Move continuously in the direction the object is facing
        transform.position += currentDirection * pythonSpeed * Time.deltaTime;

        // Handle direction change based on input
        HandleDirectionChange();
    }

    void HandleDirectionChange()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentDirection != Vector3.down) // Move Up
        {
            currentDirection = Vector3.up; // Move Up
            transform.rotation = Quaternion.Euler(0, 0, 0); // Rotate to face Up

        }
        else if (Input.GetKeyDown(KeyCode.A) && currentDirection != Vector3.right) // Move Left
        {
            currentDirection = Vector3.left; // Move Left
            transform.rotation = Quaternion.Euler(0, 0, 90); // Rotate to face Left
        }
        else if (Input.GetKeyDown(KeyCode.S) && currentDirection != Vector3.up) // Move Down
        {
            currentDirection = Vector3.down; // Move Down
            transform.rotation = Quaternion.Euler(0, 0, 180); // Rotate to face Down
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentDirection != Vector3.left) // Move Right
        {
            currentDirection = Vector3.right; // Move Right
            transform.rotation = Quaternion.Euler(0, 0, -90); // Rotate to face Right
        }
    }










    //Vector3 currentDirection = Vector3.up; // Snake starts moving up by default
    //float moveSpeed = 5f; // Speed of the snake

    //void Update()
    //{
    //    // Move the snake continuously in the current direction
    //    transform.position += currentDirection * moveSpeed * Time.deltaTime;

    //    // Check for input to change direction
    //    if (Input.GetKeyDown(KeyCode.W) && currentDirection != Vector3.down)
    //    {
    //        currentDirection = Vector3.up; // Move Up
    //    }
    //    else if (Input.GetKeyDown(KeyCode.A) && currentDirection != Vector3.right)
    //    {
    //        currentDirection = Vector3.left; // Move Left
    //    }
    //    else if (Input.GetKeyDown(KeyCode.S) && currentDirection != Vector3.up)
    //    {
    //        currentDirection = Vector3.down; // Move Down
    //    }
    //    else if (Input.GetKeyDown(KeyCode.D) && currentDirection != Vector3.left)
    //    {
    //        currentDirection = Vector3.right; // Move Right
    //    }
    //}
}
