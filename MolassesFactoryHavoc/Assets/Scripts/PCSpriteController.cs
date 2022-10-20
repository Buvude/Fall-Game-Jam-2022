using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PCSpriteController : MonoBehaviour
{
    public GameObject self;
    public Animator animationController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //call this function to start the walk cycle
    public void WalkCycleStart()
    {
        animationController.SetBool("Walking", true);
    }
    //call this function to end the walk cycle
    public void WalkCycleEnd()
    {
        animationController.SetBool("Walking", false);
    }
}
