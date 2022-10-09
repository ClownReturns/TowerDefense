using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Sound ambient;
    [SerializeField] private Sound walk;
    [SerializeField] private Sound shoot;

    private void Awake()
    {
        ambient.source = gameObject.AddComponent<AudioSource>();
        ambient.source.clip = ambient.clip;
        ambient.source.volume = ambient.volume;
        ambient.source.pitch = ambient.pitch;
        ambient.source.loop = true;

        walk.source = gameObject.AddComponent<AudioSource>();
        walk.source.clip = walk.clip;
        walk.source.volume = walk.volume;
        walk.source.pitch = walk.pitch;

        shoot.source = gameObject.AddComponent<AudioSource>();
        shoot.source.clip = shoot.clip;
        shoot.source.volume = shoot.volume;
        shoot.source.pitch = shoot.pitch;
    }
    private void Start()
    {
        ambient.source.Play();
        InputHandlerComponent.Instance.OnMoveEvent += SoundManager_OnMoveEvent;
        InputHandlerComponent.Instance.OnShootEvent += SoundManager_OnShootEvent;
    }

    public void SoundManager_OnMoveEvent(KeyCode key)
    {
        if (!walk.source.isPlaying)
        {
            walk.source.Play();
        }
    }

    public void SoundManager_OnShootEvent(object sender, EventArgs args)
    {
        shoot.source.Play();
    }
}
