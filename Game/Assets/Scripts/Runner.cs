using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] RoadLine roadline;
    [SerializeField] float positionX = 3.5f;

    private void OnEnable()
    {
        InputManager.Instance.keyAction += OnKeyUpdate;
    }

    void Start()
    {
        roadline = RoadLine.MIDDLE;
        animator = GetComponent<Animator>();
    }

    void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadline != RoadLine.LEFT)
            {
                roadline--;
                animator.Play("Left Move");
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadline != RoadLine.RIGHT)
            {
                roadline++;
                animator.Play("Right Move");
            }
        }
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = new Vector3(positionX * (float)roadline, 0, 0);
    }

    private void OnDisable()
    {
        InputManager.Instance.keyAction -= OnKeyUpdate;
    }
}