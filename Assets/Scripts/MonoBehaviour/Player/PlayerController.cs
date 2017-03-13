using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    protected override float GetInput()
    {
        float input = 0;
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
        input = Input.touchCount > 0 ? 1 : 0;
#else
        input = Input.GetAxis("Fire1");
#endif
        print(input);
        return input;

    }
}
