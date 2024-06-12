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

    void Start()
    {
        roadline = RoadLine.MIDDLE;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(roadline != RoadLine.LEFT)
            {
                roadline--;
                animator.Play("Left Move");
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadline != RoadLine.RIGHT)
            {
                roadline++;
                animator.Play("Right Move");
            }
        }

        Status(roadline);
    }

    public void Status(RoadLine roadLine)
    {
        switch(roadLine)
        {
            case RoadLine.LEFT: Move(-positionX);
                break;
            case RoadLine.MIDDLE: Move(0);
                break;
            case RoadLine.RIGHT: Move(positionX);
                break;
        }
    }

    public void Move(float positionX)
    {
        transform.position = new Vector3(positionX, 0, 0);
    }
}