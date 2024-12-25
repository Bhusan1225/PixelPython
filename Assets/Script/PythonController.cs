using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PythonController : MonoBehaviour
{

    public float pythonSpeed = 1f;
    Vector3 currentDirection = Vector3.up;

    //segment of python 
    private List<Transform> segments;
    public Transform segmentPrefab;


    
    //script access
    public AppleSpawnManager spawnManager;
    public PointController pointController;
    


    

    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
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
            
        }
        else if (Input.GetKeyDown(KeyCode.A) && currentDirection != Vector3.right) // Move Left
        {
            currentDirection = Vector3.left; // Move Left
           
        }
        else if (Input.GetKeyDown(KeyCode.S) && currentDirection != Vector3.up) // Move Down
        {
            currentDirection = Vector3.down; // Move Down
            
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentDirection != Vector3.left) // Move Right
        {
            currentDirection = Vector3.right; // Move Right
            
        }
        
    }

public void appleEaten() 
{
        spawnManager.noAppleThere();
}

public void pointScored()
    {
        pointController.getPoint(1);
    }


}
