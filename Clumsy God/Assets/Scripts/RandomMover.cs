using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMover : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float minY;
    [SerializeField] float maxX;
    [SerializeField] float maxY;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float timeToMaxDifficulty;
    [SerializeField] float speed;
    
    public bool movement = true;
    
    Vector3 targetPosition;
    float difficulty;
    
    
    void Start()
    {
        targetPosition = randomPosition();
        
    }

    
    void Update()
    {
        GetDifficulty();
        
        if (movement)
        {
            if ( transform.position != targetPosition)
            {                                       
                speed = Mathf.Lerp( minSpeed, maxSpeed, difficulty);
                transform.position = Vector2.MoveTowards( transform.position, targetPosition, speed * Time.deltaTime);
            }

            else
                targetPosition = randomPosition();
        }
    }

    Vector2 randomPosition()
    {
        return new Vector3( Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
    }

   


    void GetDifficulty()
    {
        difficulty = Mathf.Clamp01(Time.timeSinceLevelLoad / timeToMaxDifficulty);
    }

    void OnTriggerEnter2D (Collider2D other) 
    {
            movement = false;                       //why only stopping collided planets? but thats good maybe?
    }
}
