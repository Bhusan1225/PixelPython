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

    public float pythonSpeed = 5f;
    public float python2Speed = 5f;
    private Vector3 player1Direction = Vector3.up;
    private Vector3 player2Direction = Vector3.left;
    public GameObject Python2;

    //segment of python 
    internal List<Transform> segments;
    public Transform segmentPrefab;

    //powerup
    internal bool hasShield = false;
    internal bool scoreBoostActive = false;
    private bool  hasSpeedboosterActive = false;

    public float speedMultiplier = 1.5f; // Speed boost multiplier
    public float shieldDuration = 15f; // Duration for shield
    public float scoreBoostDuration = 5f; // Duration for score boost

    //script access
    public AppleSpawnManager spawnManager;
    public PointController pointController;


    //ScoreBooster on
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

        //logic of speed booster but facing truble

        //if (hasSpeedboosterActive == true)
        //{
        //    pythonSpeed = 2 * pythonSpeed;
        //}
        //else
        //{
        //    pythonSpeed = 1 * pythonSpeed;
        //}


        MovePlayer1();
        MovePlayer2();
    }
    private void Update()
    {
        // Handle direction change based on input
        HandlePlayer1DirectionChange();
        HandlePlayer2DirectionChange();
    }

    void MovePlayer1()
    {
        // Move Player 1 continuously in the current direction
        transform.position += player1Direction * pythonSpeed * Time.deltaTime;

        
        transform.position = new Vector3(
            Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y),
            0.0f
        );
    }

    void MovePlayer2()
    {
        Vector3 python2Position = Python2.transform.position;

        python2Position += player2Direction * python2Speed * Time.deltaTime;


        python2Position = new Vector3(
            Mathf.Round(python2Position.x),
            Mathf.Round(python2Position.y),
            0.0f
        );
        Python2.transform.position = python2Position;
    }

    //player 1
    void HandlePlayer1DirectionChange()
    {
        if (Input.GetKeyDown(KeyCode.W) && player1Direction != Vector3.down) // Player 1 Move Up
        {
            player1Direction = Vector3.up; // Move Up
        }
        else if (Input.GetKeyDown(KeyCode.A) && player1Direction != Vector3.right) // Player 1 Move Left
        {
            player1Direction = Vector3.left; // Move Left
        }
        else if (Input.GetKeyDown(KeyCode.S) && player1Direction != Vector3.up) // Player 1 Move Down
        {
            player1Direction = Vector3.down; // Move Down
        }
        else if (Input.GetKeyDown(KeyCode.D) && player1Direction != Vector3.left) // Player 1 Move Right
        {
            player1Direction = Vector3.right; // Move Right
        }
    }
    //player 2
    void HandlePlayer2DirectionChange()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && player2Direction != Vector3.down) // Player 2 Move Up
        {
            player2Direction = Vector3.up; // Move Up
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && player2Direction != Vector3.right) // Player 2 Move Left
        {
            player2Direction = Vector3.left; // Move Left
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && player2Direction != Vector3.up) // Player 2 Move Down
        {
            player2Direction = Vector3.down; // Move Down
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && player2Direction != Vector3.left) // Player 2 Move Right
        {
            player2Direction = Vector3.right; // Move Right
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
            
            Invoke(nameof(DeactivateShield), shieldDuration);
            
        }
    }

    private void DeactivateShield()
    {

        hasShield = false;
       

    }

    private void ActivateScoreBoost()
    {
        if (!scoreBoostActive)
        {
            scoreBoostActive = true;
            Debug.Log("Score Boost Activated!");
            
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
        if (!hasSpeedboosterActive)
        {
            hasSpeedboosterActive = true;
            Debug.Log("Speed Up Activated!");
            Invoke(nameof(DeactivateSpeedUp), shieldDuration); // Restore original speed after duration
        }
    }
       
        
        

    private void DeactivateSpeedUp()
    {
        hasSpeedboosterActive = false;
        
        Debug.Log("Speed Up Deactivated!");
    }
}

