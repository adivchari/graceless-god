using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonShooter : MonoBehaviour
{
    [SerializeField] GameObject moon;
    [SerializeField] GameObject[] otherPlanets;
    [SerializeField] int speed;
    [SerializeField] float timeBtwShot;
    [SerializeField] float startTimeBtwShot;
    [SerializeField] float reduceTimeBtwShot;
    [SerializeField] Vector2 moonPos;
    [SerializeField] Vector2 target;

    

    void Start()
    {
        timeBtwShot = startTimeBtwShot;
    }

    
    void Update()
    {
        if ( timeBtwShot <= 0)
        {
            startTimeBtwShot -= reduceTimeBtwShot;
            shootMoon();
            timeBtwShot = startTimeBtwShot;
        }
            
        else
            timeBtwShot -= Time.deltaTime;

    }

    void shootMoon()
    {
        Vector2 moonPos = new Vector2(transform.position.x + 0.24f, transform.position.y + 0.24f);
        Instantiate(moon, moonPos, Quaternion.identity);
        moveMoon();
    }

    void moveMoon()
    {
        moon.transform.position = Vector2.MoveTowards(moonPos, target, speed * Time.deltaTime);
    }

    
}
