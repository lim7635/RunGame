using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedManager : State
{
    [SerializeField] static float speed;
    [SerializeField] float limitSpeed = 60.0f;

    [SerializeField] UnityEvent callback;

    public static float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public void Awake()
    {
        speed = 20.0f;

        StartCoroutine(Increase());
    }

    public IEnumerator Increase()
    {
        while (speed < limitSpeed && state == true)
        {
            if(callback != null)
            {
                callback.Invoke();
            }

            yield return new WaitForSeconds(2.5f);

            speed++;
        }
    }
}