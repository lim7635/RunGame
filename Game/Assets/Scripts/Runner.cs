using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

[RequireComponent(typeof(Rigidbody))]
public class Runner : State
{
    [SerializeField] Animator animator;
    [SerializeField] AudioClip sound;

    [SerializeField] RoadLine roadline;
    [SerializeField] RoadLine previousline;

    [SerializeField] float speed = 5.0f;
    [SerializeField] float positionX = 3.5f;

    private void OnEnable()
    {
        base.OnEnable();

        InputManager.Instance.keyAction += OnKeyUpdate;
    }

    void Awake()
    {
        roadline = previousline = RoadLine.MIDDLE;

        animator = GetComponent<Animator>();

        Initialize();
    }

    public void Initialize()
    {
        animator.speed = SpeedManager.Speed / 20.0f;
    }

    void OnKeyUpdate()
    {
        if (state == false) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            previousline = roadline;

            if (roadline != RoadLine.LEFT)
            {
                roadline--;

                SoundManager.Instance.Sound(sound);

                animator.Play("Left Move");
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            previousline = roadline;

            if (roadline != RoadLine.RIGHT)
            {
                roadline++;

                SoundManager.Instance.Sound(sound);

                animator.Play("Right Move");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IHitable hitable = other.GetComponent<IHitable>();

        if(hitable != null)
        {
            hitable.Activate(this);
        }
    }

    public void Die()
    {
        animator.Play("Die");
    }

    public void RevertPosition()
    {
        roadline = previousline;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (state == false) return;

        transform.position = Vector3.Lerp
        (
            transform.position,
            new Vector3(positionX * (float)roadline, 0, 0),
            speed * Time.deltaTime
        );
    }

    private void OnDisable()
    {
        base.OnDisable();

        InputManager.Instance.keyAction -= OnKeyUpdate;
    }
}