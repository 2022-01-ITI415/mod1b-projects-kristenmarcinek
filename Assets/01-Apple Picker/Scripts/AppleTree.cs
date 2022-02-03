using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where the AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change direction
    public float chanceToChangeDirection;

    // Rate at which Apples with instantiate
    public float secondsBetweenAppleDrop;
    
    // Start is called before the first frame update
    void Start()
    {
      
      // Dropping apples every second  

    }

    // Update is called once per frame
    void Update()
    {
        
        // Basic Movement

        // Changing Direction

    }
}
