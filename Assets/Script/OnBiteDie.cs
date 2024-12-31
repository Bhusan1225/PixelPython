using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnBiteDie : MonoBehaviour
{  //UI
    public GameObject gameoverCanvas;
    public GameObject gameWinCanvasGreen;
    public Button GReplayButton;
    public Button GQuitButton;

    public Button OReplayButton;
    public Button OQuitButton;
    

    // Start is called before the first frame update
    void Start()
    {
        GReplayButton.onClick.AddListener(OnClickReplay);
        GQuitButton.onClick.AddListener(OnClickQuit);

        OReplayButton.onClick.AddListener(OnClickReplay);
        OQuitButton.onClick.AddListener(OnClickQuit);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PythonController python = FindAnyObjectByType<PythonController>();
                       
        if (collision.gameObject.CompareTag("Python Body") && python.hasShield == false)// working properlys
        {
            Debug.Log("ohh... shit I bite myself.");

            gameoverCanvas.SetActive(true);
            Destroy(gameObject, 20);
            return;
            
        }
        Python2Controller python2 = FindAnyObjectByType<Python2Controller>();
        if (collision.gameObject.CompareTag("Python2 Body") && python2.hasShield == false)// working properlys
        {
            Debug.Log("Yesss I bite him and win.");

            gameWinCanvasGreen.SetActive(true);
            Destroy(gameObject, 20);
            return;
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
