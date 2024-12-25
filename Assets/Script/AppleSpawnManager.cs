using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawnManager : MonoBehaviour
{
    public bool isAppleThere = false;

    public GameObject Apple;

    public Vector3 spawnAreaMin = new Vector2(-8, -8);
    public Vector3 spawnAreaMax = new Vector2(8, 8);

    public Quaternion AppleSpawnRotation = Quaternion.identity;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isAppleThere = false;
        }


        spawnLoop();
    }

    public void spawnLoop()
    {

        
        while(isAppleThere == false)
        {
            //logic of apple spawning and in logic make the isAppleThere == True;
            spawnApple();
            
        }
    }

    public void spawnApple()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );
        
        Debug.Log("apple spawned");
        Instantiate(Apple, randomPosition, AppleSpawnRotation); //for spawning apple this will work

     


        isAppleThere = true;
    }

    public void noAppleThere()
    {
        isAppleThere = false;
    }

}