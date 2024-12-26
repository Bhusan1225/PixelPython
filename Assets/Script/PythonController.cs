using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    //UI
    public GameObject gameoverCanvas;
    public Button ReplayButton;
    public string sceneName;
    

    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);

        ReplayButton.onClick.AddListener(OnClickReplay);
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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Python Body"))
        {
            Debug.Log("ohh... shit I bite myself.");
            
            gameoverCanvas.SetActive(true);
            Destroy(gameObject, 10);
        }
    }
    
    void OnClickReplay()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Replay button clicked.");
        SceneManager.LoadScene(sceneName);

    }

}
