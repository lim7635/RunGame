using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
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
    [SerializeField] Rigidbody rigidBody;

    [SerializeField] Animator animator;
    [SerializeField] AudioClip sound;

    [SerializeField] RoadLine roadline;
    [SerializeField] RoadLine previousline;

    [SerializeField] bool jump = true;
    [SerializeField] float jumpPower = 10.0f;
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

        rigidBody = GetComponent<Rigidbody>();
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

        if(jump == true && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
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

    private void OnCollisionEnter(Collision collision)
    {
        IHitable hitable = collision.transform.GetComponent<IHitable>();

        if (hitable != null)
        {
            hitable.Activate(this);
        }
    }

    public void Die()
    {
        animator.Play("Die");
    }

    public void Jump()
    {
        jump = false;

        animator.Play("Jump");

        rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    public void Possible()
    {
        jump = true;

        animator.SetTrigger("Active");
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

        rigidBody.position = Vector3.Lerp
        (
            rigidBody.position,
            new Vector3(positionX * (float)roadline, rigidBody.position.y, 0),
            speed * Time.deltaTime
        );
    }

    private void OnDisable()
    {
        base.OnDisable();

        InputManager.Instance.keyAction -= OnKeyUpdate;
    }
}