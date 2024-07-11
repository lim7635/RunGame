using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasCamera : MonoBehaviour
{
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnsceneLoaded;
    }

    void OnsceneLoaded(Scene scene, LoadSceneMode mode)
    {
        canvas.worldCamera = Camera.main;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnsceneLoaded;
    }
}