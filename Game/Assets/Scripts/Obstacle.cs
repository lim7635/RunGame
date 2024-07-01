using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : State, IInteractable
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
        base.OnEnable();

        direction = Vector3.forward;
    }

    void Update()
    {
        if (state == false) return;

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void Interact()
    {
        gameObject.SetActive(false);
    }
}