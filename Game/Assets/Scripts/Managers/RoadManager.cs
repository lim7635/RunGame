using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads; // C++ = vector
    [SerializeField] float speed = 10.0f;
    [SerializeField] float offset = 20.0f;

    void Start()
    {
        roads.Capacity = 10;
    }

    void Update()
    {
        for(int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    public void NewPosition()
    {
        GameObject newRoad = roads[0];

        roads.Remove(newRoad);

        float newZ = roads[roads.Count - 1].transform.position.z + offset;

        newRoad.transform.position = new Vector3(0, 0, newZ);

        roads.Add(newRoad);
    }
}