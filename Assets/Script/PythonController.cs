using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class PythonController : MonoBehaviour
{

    public float pythonSpeed = 1f;
    Vector3 currentDirection = Vector3.up;

    //segment of python 
    internal List<Transform> segments;
    public Transform segmentPrefab;

    //powerup
    internal bool hasShield = false;
    internal bool scoreBoostActive = false;
    private bool hasSpeedboosterActive = false;

    public float speedMultiplier = 1.5f; // Speed boost multiplier
    public float shieldDuration = 15f; // Duration for shield
    public float scoreBoostDuration = 5f; // Duration for score boost

    //script access
    public AppleSpawnManager spawnManager;
    public PointController pointController;


    //ScoreBooster on
    private OnBiteDie onBiteDie;
    public PoisonTrigger poisonTrigger;

    //batch update
    public GameObject GScoreBoost;
    public GameObject GSpeedBoost;
    public GameObject GShild;



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

        //logic of speed booster but facing truble
        
        //if (hasSpeedboosterActive == true)
        //{
        //    pythonSpeed = 2 * pythonSpeed;
        //}
        //else
        //{
        //    pythonSpeed = 1 * pythonSpeed;
        //}


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
        pointController.checkScoreboosterON_OFF();
    }

    public void pointLoose()
    {
        pointController.checkShieldON_OFF();
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
            GShild.SetActive(true);
            Invoke(nameof(DeactivateShield), shieldDuration);
            
        }
    }

    private void DeactivateShield()
    {

        hasShield = false;
        GShild.SetActive(false);

    }

    private void ActivateScoreBoost()
    {
        if (!scoreBoostActive)
        {
            scoreBoostActive = true;
            Debug.Log("Score Boost Activated!");
            GScoreBoost.SetActive(true);
            Invoke(nameof(DeactivateScoreBoost), scoreBoostDuration);
        }
    }

    private void DeactivateScoreBoost()
    {
        scoreBoostActive = false;
        GScoreBoost.SetActive(false);
        Debug.Log("Score Boost Deactivated!");
    }

    private void ActivateSpeedUp()
    {
        if (!hasSpeedboosterActive)
        {
            hasSpeedboosterActive = true;
            Debug.Log("Speed Up Activated!");
            GSpeedBoost.SetActive(true);
            Invoke(nameof(DeactivateSpeedUp), shieldDuration); // Restore original speed after duration
        }
    }
       
        
        

    private void DeactivateSpeedUp()
    {
        hasSpeedboosterActive = false;
        GSpeedBoost.SetActive(false);
        Debug.Log("Speed Up Deactivated!");
    }
}

