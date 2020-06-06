using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerIdleSwitch : MonoBehaviour
{
    private Animator animator;
    private System.Random rng = new System.Random();
    private float timeSinceLastChange = 0;
    private float timeBeforeNextRandomChoice = 1.5f;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        timeSinceLastChange = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if (currentTime-timeSinceLastChange > timeBeforeNextRandomChoice)
        {
            int idleState = rng.Next(0, 2);// Number between 0 and 1;
            animator.SetInteger("CurrentIdle", idleState);
            timeSinceLastChange = currentTime;
            timeBeforeNextRandomChoice = 2.0f + Convert.ToSingle(rng.NextDouble()) - 0.5f;
        }
        
    }
}
