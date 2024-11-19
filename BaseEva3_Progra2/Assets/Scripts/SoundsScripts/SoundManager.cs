using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    MenuMusic,
    BattleMusic1,
    BattleMusic2,
    BattleMusic3,
    EndBattleMusic
}

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audioList;
    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public static void PlaySound(SoundType sound, float volume = 1)
    {
        //instance.audioSource.PlayOneShot();
    }
}
