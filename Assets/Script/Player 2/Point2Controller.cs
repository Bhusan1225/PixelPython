using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Point2Controller : MonoBehaviour
{
    public TextMeshProUGUI point2Text;
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
        PythonController python = FindAnyObjectByType<PythonController>();
        if (python.scoreBoostActive == false)
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
        point2Text.text = "PLAYER 2 Point:" + points;
    }

    public void getDoublegetPoint(int DoubleIncrement)
    {
        points += DoubleIncrement;
        point2Text.text = "PLAYER 2 Point:" + points;
    }


    public void checkShieldON_OFF()
    {
        Python2Controller python = FindAnyObjectByType<Python2Controller>();
        if (python.hasShield == true)
        {
            Debug.Log(" do not worry, shield is on you will not loose the point.");
        }
        else
        {
            LoosePoint(1);
        }
    }
    public void LoosePoint(int decrement)
    {
        points -= decrement;
        point2Text.text = "PLAYER 2 Point:" + points;
    }
}
