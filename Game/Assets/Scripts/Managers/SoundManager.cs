using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneSound
{
    Title,
    Game
}

public class SoundManager : SingleTon<SoundManager>
{
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    [SerializeField] SceneSound sceneSound;

    public void Sound(AudioClip audioClip)
    {
        effectSource.PlayOneShot(audioClip);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneSound = (SceneSound)scene.buildIndex;

        scenerySource.clip = ResourcesManager.Instance.Load<AudioClip>(sceneSound.ToString());

        scenerySource.loop = true;

        scenerySource.Play();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}