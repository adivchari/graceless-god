using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    bool moveAllowed = false;
    Collider2D planetCollider;

    void Start() 
    {
        planetCollider = GetComponent<Collider2D>();        
    }
    
    void Update()
    {
        if( Input.touchCount > 0)                     //if finger is touching screen
            PlayerControlsPlanet();
    }




    void PlayerControlsPlanet()
    {
        Touch touch = Input.GetTouch(0);                                               //pixel coordinates
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);    //converts pixel coordinates to world coordinates

        if ( touch.phase == TouchPhase.Began)
        {
            Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);       //gets collider of object at pos we touch
            if ( touchedCollider == planetCollider)
                moveAllowed = true;
        }

        if ( touch.phase == TouchPhase.Moved)
        {
            if ( moveAllowed)
                transform.position = new Vector2( touchPosition.x, touchPosition.y);
        }

        if ( touch.phase == TouchPhase.Ended)
        {
            moveAllowed = false;
        }
    }
}