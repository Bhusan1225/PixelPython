using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Button playButton;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(OnClickPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickPlay()
    {
       
        SceneManager.LoadScene(sceneName);

    }
}
