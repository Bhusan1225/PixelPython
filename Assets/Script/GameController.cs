using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   // public static GameController Instance { get; private set; }

    public Button SplayButton;
    public Button MplayButton;
    public Button InfoButton;

    public string SsceneName;
    public string MsceneName;
    public string IsceneName;

    // Start is called before the first frame update
    void Start()
    {
        SplayButton.onClick.AddListener(SOnClickPlay);
        MplayButton.onClick.AddListener(MOnClickPlay);
        InfoButton.onClick.AddListener(InfoOnClickPlay);
    }

    //private void Awake()
    //{
        
    //    if (Instance != null && Instance != this)
    //    {
    //        Destroy(gameObject); 
    //        return;
    //    }

    //    Instance = this; 
    //    DontDestroyOnLoad(gameObject); 
    //}

    void SOnClickPlay()
    {
       
        SceneManager.LoadScene(SsceneName);

    }
    void MOnClickPlay()
    {

        SceneManager.LoadScene(MsceneName);

    }
    void InfoOnClickPlay()
    {

        SceneManager.LoadScene(IsceneName);

    }
}
