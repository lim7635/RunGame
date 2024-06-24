using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int random;

    [SerializeField] int randomPosition;

    [SerializeField] Transform [] activePositions;

    [SerializeField] GameObject [] obstaclePrefabs;

    [SerializeField] List<GameObject> obstacleList;

    void Start()
    {
        obstacleList.Capacity = 10;

        Create();

        StartCoroutine(ActiveObstacle());
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

    public IEnumerator ActiveObstacle()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(5f);

        while (true)
        {
            random = Random.Range(0, obstacleList.Count);
            randomPosition = Random.Range(0, activePositions.Length);

            if(obstacleList[random].activeSelf == true)
            {
                random = (random + 1) % obstacleList.Count;
            }

            obstacleList[random].SetActive(true);
            obstacleList[random].transform.position = activePositions[randomPosition].position;

            yield return waitForSeconds;
        }
    }
}