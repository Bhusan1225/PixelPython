using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnBiteDie2 : MonoBehaviour
{  //UI
    public GameObject gameoverCanvas;
    public GameObject gameWinCanvas;
    public Button PReplayButton;
    public Button PQuitButton;


    public Button OReplayButton;
    public Button OQuitButton;

    // Start is called before the first frame update
    void Start()
    {
        PReplayButton.onClick.AddListener(OnClickReplay);
        PQuitButton.onClick.AddListener(OnClickQuit);

        OReplayButton.onClick.AddListener(OnClickReplay);
        OQuitButton.onClick.AddListener(OnClickQuit);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Python2Controller python = FindAnyObjectByType<Python2Controller>();

        if (collision.gameObject.CompareTag("Python2 Body") && python.hasShield == false)// working properlys
        {
            Debug.Log("ohh... shit I bite myself.");

            gameoverCanvas.SetActive(true);
            Destroy(gameObject, 20);

        }
        
        PythonController python1 = FindAnyObjectByType<PythonController>();
        if (collision.gameObject.CompareTag("Python Body") && python1.hasShield == false)// working properlys
        {
            Debug.Log("Yesss I bite him and win.");

            gameWinCanvas.SetActive(true);
            Destroy(gameObject, 20);

        }
    }



    void OnClickQuit()
    {
        SceneManager.LoadScene(0);

    }
    void OnClickReplay()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Replay button clicked.");
        SceneManager.LoadScene(currentSceneIndex);

    }


}

