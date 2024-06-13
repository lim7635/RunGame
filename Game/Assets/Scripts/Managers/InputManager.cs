using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingleTon<InputManager>
{
    public Action keyAction;

    void Update()
    {
        if (Input.anyKey == false)
        {
            return;
        }

        if (keyAction != null)
        {
            keyAction.Invoke();
        }
    }
}