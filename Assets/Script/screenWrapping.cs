using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenWrapping : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;
  

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        // Calculate the screen bounds based on camera size
        screenBounds = new Vector2(mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize);
    }

    void Update()
    {
        Vector3 position = transform.position;
        
        
        // Check if the object is outside the screen bounds and wrap it
        if (position.x > screenBounds.x)
        {
            position.x = -screenBounds.x;
            
        }
        else if (position.x < -screenBounds.x)
        {
            position.x = screenBounds.x;
            
        }

        if (position.y > screenBounds.y)
        {
            position.y = -screenBounds.y;
            
        }
        else if (position.y < -screenBounds.y)
        {
            position.y = screenBounds.y;
            
        }

        // Apply the wrapped position back to the object
        transform.position = position;

        
    }
}
