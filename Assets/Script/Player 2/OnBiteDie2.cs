using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnBiteDie2 : MonoBehaviour
{  //UI
    public GameObject gameoverCanvas;
    public Button ReplayButton;
    public Button QuitButton;

    


    // Start is called before the first frame update
    void Start()
    {
        ReplayButton.onClick.AddListener(OnClickReplay);
        QuitButton.onClick.AddListener(OnClickQuit);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Python2Controller python = FindAnyObjectByType<Python2Controller>();

        if (collision.gameObject.CompareTag("Python Body") && python.hasShield == false)// working properlys
        {
            Debug.Log("ohh... shit I bite myself.");

            gameoverCanvas.SetActive(true);
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

