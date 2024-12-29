using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum PowerupEnum
{
    Shield,
    ScoreBoost,
    SpeedUp
}

public class PythonController : MonoBehaviour
{

    public float pythonSpeed = 1f;
    Vector3 currentDirection = Vector3.up;

    //segment of python 
    private List<Transform> segments;
    public Transform segmentPrefab;

    //powerup
    private bool hasShield = false;
    private bool scoreBoostActive = false;
    //private float originalSpeed;
    public float speedMultiplier = 1.5f; // Speed boost multiplier
    public float shieldDuration = 15f; // Duration for shield
    public float scoreBoostDuration = 5f; // Duration for score boost

    //script access
    public AppleSpawnManager spawnManager;
    public PointController pointController;


    //Shield on
    private OnBiteDie onBiteDie;
    public PoisonTrigger poisonTrigger;
    
    

    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
        onBiteDie = GetComponent<OnBiteDie>();


    }

    private void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        // Move continuously in the direction the object is facing
        transform.position += currentDirection * pythonSpeed;

        transform.position = new Vector3(
        Mathf.Round(transform.position.x),
        Mathf.Round(transform.position.y),
        0.0f);
    }
    private void Update()
    {
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


//python grow logic is here

    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }

    public void strinking()
    {
        if (!hasShield)
        {
            Shrink();
        }

        
    }
    public void Shrink()
    {
        
        if (segments.Count > 1)
        {
            
            Transform lastSegment = segments[segments.Count - 1];

             segments.RemoveAt(segments.Count - 1);

            
            Destroy(lastSegment.gameObject);
        }
        else
        {
            Debug.Log("Cannot shrink further, only the head remains!");
        }
    }



    
    //POWER UPS

    public void ActivatePowerUp(PowerupEnum powerUpType)
    {
        switch (powerUpType)
        {
            case PowerupEnum.Shield:
                ActivateShield();
                break;
            case PowerupEnum.ScoreBoost:
                ActivateScoreBoost();
                break;
            case PowerupEnum.SpeedUp:
                ActivateSpeedUp();
                break;
        }
    }

    private void ActivateShield()
    {
        if (!hasShield)
        {
            hasShield = true;
            GetComponent<OnBiteDie>().isShieldActive = true;
            //GetComponent<OnBiteDie>().enabled = false;
            
            //check
            //poisonTrigger.isShieldActiveP = true;
            Invoke(nameof(DeactivateShield), shieldDuration);
            
        }
    }

    private void DeactivateShield()
    {
        hasShield = false;
        //GetComponent<OnBiteDie>().enabled = true; //
        GetComponent<OnBiteDie>().isShieldActive = false;
        
        
        //check 
        //poisonTrigger.isShieldActiveP = false;



    }

    private void ActivateScoreBoost()
    {
        if (!scoreBoostActive)
        {
            scoreBoostActive = true;
            Debug.Log("Score Boost Activated!");
            // Logic to double score points (handled in your scoring system)
            Invoke(nameof(DeactivateScoreBoost), scoreBoostDuration);
        }
    }

    private void DeactivateScoreBoost()
    {
        scoreBoostActive = false;
        Debug.Log("Score Boost Deactivated!");
    }

    private void ActivateSpeedUp()
    {
        Debug.Log("Speed Up Activated!");
        GetComponent<Rigidbody>().velocity *= speedMultiplier; // Increase speed
        Invoke(nameof(DeactivateSpeedUp), shieldDuration); // Restore original speed after duration
    }

    private void DeactivateSpeedUp()
    {
        GetComponent<Rigidbody>().velocity /= speedMultiplier; // Restore original speed
        Debug.Log("Speed Up Deactivated!");
    }
}































