using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointController : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    int points = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void checkScoreboosterON_OFF()
    {
        PythonController pythonController = FindAnyObjectByType<PythonController>();
        if (pythonController.scoreBoostActive ==false)
        {
            getPoint(1);
        }
        else
        {
            getDoublegetPoint(2);
        }
    }
    public void getPoint(int increment)
    {
        points += increment;
        pointText.text = "Point:" + points;
    }

    public void getDoublegetPoint(int DoubleIncrement)
    {
        points += DoubleIncrement;
        pointText.text = "Point:" + points;
    }
}
