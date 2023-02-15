using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D Effector;

    private void Start()
    {
        Effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Effector.rotationalOffset = 180f;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            Effector.rotationalOffset = 0f;
        }

    }
}

