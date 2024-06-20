using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] GameObject [] obstaclePrefabs;
    [SerializeField] List<GameObject> obstacleList;

    void Start()
    {
        obstacleList.Capacity = 10;

        Create();
    }

    public void Create()
    {
        for (int i = 0; i < obstaclePrefabs.Length; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefabs[i]);

            obstacle.SetActive(false);

            obstacleList.Add(obstacle);
        }
    }
}