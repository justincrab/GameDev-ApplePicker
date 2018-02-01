using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    // Prefab for instantiating apples
    public GameObject applePrefab;
    // Speed at which the AppleTree moves in meters/second
    public float speed = 1f;
    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;
    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;
    // Rate at which teh Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;
	// Use this for initialization
	void Start () {
        // Dropping apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
	}
    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        } 
	}
    void FixedUpdate()
    {
        // Changing direction randomly
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
