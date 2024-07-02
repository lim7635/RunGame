using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : State, IInteractable
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void OnEnable()
    {
        base.OnEnable();

        speed = Random.Range(SpeedManager.Speed, SpeedManager.Speed + 5);

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