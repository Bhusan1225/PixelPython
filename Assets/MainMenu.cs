using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button MainMenuButton;
    

    


    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton.onClick.AddListener(OnClickPlay);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClickPlay()
    {

        SceneManager.LoadScene(0);

    }
    
}
