﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OutlinePulser : MonoBehaviour {
    public PulseManager pulseManager;
    private float pulse;
    private int colorIndex;
    private bool trajectory;


    // Use this for initialization
    void Start()
    {
        trajectory = true;
    }

    // Update is called once per frame
    void Update()
    {

        float prevPulse = pulse;
        pulse = Mathf.PingPong(Time.time * pulseManager.speed, 1);


        Color oldColor = GetComponent<Outline>().effectColor;
        GetComponent<Outline>().effectColor = new Color(oldColor.r, oldColor.g, oldColor.b, pulse);

        bool prevTrajectory = trajectory;
        if (prevPulse < pulse)
            trajectory = false;

        if (prevPulse > pulse)
            trajectory = true;


        if (prevTrajectory == true && trajectory == false)
        {
            GetComponent<Outline>().effectColor = pulseManager.colors[colorIndex];

            if (colorIndex < pulseManager.colors.Length - 1)
                colorIndex++;
            else
                colorIndex = 0;
        }
    }
}
