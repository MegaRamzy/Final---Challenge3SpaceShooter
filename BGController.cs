using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    private Vector3 startPosition;

/*
*   public GameController gC;
*   public ParticleSystem psMain;  (Error Code)
*   
*   private ParticleSystem ps;  (Error Code)
*   public float hSliderValue = 1.0F;   (Error Code)
*  public ParticleSystem speed;    (Error Code)
*/

    void Start()
    {
        startPosition = transform.position;

//      ps = GetComponent<ParticleSystem>();  (Error Code)

    }

    void Update()
    {

        /*    (Message) -- (Code Error)  
        *       ParticleSystem.MainModule psMain = speed.main;   (Error Code)
        *       ParticleSystem.ShapeModule psShape = speed.shape;    (Error Code)
        *
        *       var main = ps.main;   (Error Code)
        *       main.simulationSpeed = hSliderValue;   (Error Code)
        */

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        /*  (Message) -- broken code?? worked on Time Attack scene but breaks every other scene.
        *       if (gC.restart == true)
        *       {
        *           for (scrollSpeed = -.45f; scrollSpeed > -5; scrollSpeed -= .1f) ;
        *
        *           psMain.startLifetime = 100.0f; (Error Code)
        *           psMain.startSpeed = 100.0f;   (Error Code)
        *       }
        *
        *    void OnGUI()
        *    {
        *        hSliderValue = GUI.HorizontalSlider(new Rect(25, 45, 100, 30), hSliderValue, 0.0F, 5.0F);
        *    }   
        */    
    }  
    
}


/*   (Message) -- Error Code of not being able to adjust the particle sysetm. Wasn't able to figure it out. (yet)
* 
*   NullReferenceException: Do not create your own module instances, get them from a ParticleSystem instance
*   UnityEngine.ParticleSystem+MainModule.set_simulationSpeed(System.Single value) <0x1c401f57d50 + 0x00062> in <171d57267e034dac885b879a27b3e82b>:0
*/