using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timer;
    float shotClock = 24f;
    [SerializeField] GameObject winScreen;
    [SerializeField] AudioSource winSound;
    
    
    
    
    void Start()
    {
        timer = GetComponent<Text>();
        winSound = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
        //reduce time, display time, if timer 0 instantiate panel that says level complete
        if (shotClock > 0)
        {
            shotClock -= Time.deltaTime;
            timer.text = shotClock.ToString("F0");     //only displays the integer
        }
        else
            WinScreen();

    }

    void WinScreen()
    {
        RandomMover.movement = false;
        winScreen.SetActive(true);
        
    }
}
