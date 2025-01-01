using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Button SplayButton;
    public Button MplayButton;
    public Button InfoButton;

    public string SsceneName;
    public string MsceneName;

    // Start is called before the first frame update
    void Start()
    {
        SplayButton.onClick.AddListener(SOnClickPlay);
        MplayButton.onClick.AddListener(MOnClickPlay);
        InfoButton.onClick.AddListener(InfoOnClickPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

        SceneManager.LoadScene(2);

    }
}
