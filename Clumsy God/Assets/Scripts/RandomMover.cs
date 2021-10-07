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
    [SerializeField] float speed;
    Vector3 targetPosition;
    
    void Start()
    {
        targetPosition = randomPosition();
    }

    
    void Update()
    {
        if ( transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards( transform.position, targetPosition, speed * Time.deltaTime);
        }

        else
            targetPosition = randomPosition();
        
    }

    Vector2 randomPosition()
    {
        return new Vector3( Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
    }

    void OnTriggerEnter2D( Collider2D collision)
    {
        if ( collision.tag == "Planet")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
