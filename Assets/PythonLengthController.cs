using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PythonLengthController : MonoBehaviour
{
    public GameObject bodyPrefab; // Prefab for the body segment
    public List<Transform> bodyParts = new List<Transform>(); // List of body parts
    public float minDistance = 0.5f; // Minimum distance between segments
    private Transform lastBodyPart; // The last body part of the snake

    void Start()
    {
        lastBodyPart = transform; // Initially, the head is the only body part
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddBodySegment()
    {
        // Instantiate a new body part at the position of the last body part
        Vector3 newPosition = lastBodyPart.position - lastBodyPart.forward * minDistance;
        GameObject newBodyPart = Instantiate(bodyPrefab, newPosition, Quaternion.identity);

        // Add it to the list and update the last body part
        bodyParts.Add(newBodyPart.transform);
        lastBodyPart = newBodyPart.transform;
    }
}
