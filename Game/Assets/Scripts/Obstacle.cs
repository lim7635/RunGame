using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] Vector3 direction;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void OnEnable()
    {
        direction = Vector3.forward;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}