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

    public void getPoint(int increment)
    {
        points += increment;
        pointText.text = "Point:" + points;
    }
}
