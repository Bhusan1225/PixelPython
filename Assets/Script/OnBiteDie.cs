using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnBiteDie : MonoBehaviour
{  //UI
    public GameObject gameoverCanvas;
    public Button ReplayButton;

   
    // Start is called before the first frame update
    void Start()
    {
        ReplayButton.onClick.AddListener(OnClickReplay);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PythonController python = FindAnyObjectByType<PythonController>();
                       
        if (collision.gameObject.CompareTag("Python Body") && python.hasShield == false)
        {
            Debug.Log("ohh... shit I bite myself.");

            gameoverCanvas.SetActive(true);
            Destroy(gameObject, 20);
            
        }
    }

    void OnClickReplay()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Replay button clicked.");
        SceneManager.LoadScene(currentSceneIndex);

    }

    //private IEnumerator  makeShieldOff(float delay)
    //{
    //    yield return new WaitForSeconds(delay);

    //    Destroy(gameObject);

    //}
}
