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
    [SerializeField] GameObject restartPanel;
    [SerializeField] float speed;
    [SerializeField] ParticleSystem planetDamage;
    
    Vector3 targetPosition;
    float difficulty;
    bool moveAllow = true;
    
    void Start()
    {
        targetPosition = randomPosition();
        
    }

    
    void Update()
    {
        GetDifficulty();
        
        if (moveAllow)
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

    void OnTriggerEnter2D( Collider2D collision)
    {
        if ( collision.tag == "Planet" )
        {
            restartPanel.SetActive(true);
            Instantiate(planetDamage, transform.position, Quaternion.identity);
            Debug.Log("this is executing");
            moveAllow = false;
        }
            
    }

    void GetDifficulty()
    {
        difficulty = Mathf.Clamp01(Time.timeSinceLevelLoad / timeToMaxDifficulty);
    }
}
