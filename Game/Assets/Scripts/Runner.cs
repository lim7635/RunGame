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

public class Runner : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioClip sound;

    [SerializeField] RoadLine roadline;
    [SerializeField] RoadLine previousline;

    [SerializeField] float speed = 20.0f;
    [SerializeField] float positionX = 3.5f;

    private void OnEnable()
    {
        InputManager.Instance.keyAction += OnKeyUpdate;
    }

    void Start()
    {
        roadline = previousline = RoadLine.MIDDLE;
        animator = GetComponent<Animator>();
    }

    void OnKeyUpdate()
    {
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
        transform.position = Vector3.Lerp
        (
            transform.position,
            new Vector3(positionX * (float)roadline, 0, 0),
            speed * Time.deltaTime
        );
    }

    private void OnDisable()
    {
        InputManager.Instance.keyAction -= OnKeyUpdate;
    }
}