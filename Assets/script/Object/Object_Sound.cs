using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Sound : MonoBehaviour
{
    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public AudioSource sfxPlayers;
    public bool loop;
    public SoundOption soundOption;
    void Awake()
    {
        soundOption = FindObjectOfType<SoundOption>();
        Init(); //초기화 함수
    }
    void Init()
    {
        sfxPlayers = GetComponent<AudioSource>();
        sfxPlayers.playOnAwake = false;
        sfxPlayers.loop = loop;
        sfxPlayers.volume = sfxVolume;

    }
    private void Update()
    {
        sfxPlayers.volume = soundOption.ReturnsfxVolume();
    }
    public void UpdateSfxVolume(float volume)
    {
        sfxPlayers.volume = volume;
    }
    public void PlaySfx(int sfxindex)
    {
            sfxPlayers.clip = sfxClips[sfxindex];
            sfxPlayers.Play();
    }
    public void StopSfx()
    {
        sfxPlayers.clip = null;
        sfxPlayers.Stop();
    }
    public bool isplay()
    {
        return sfxPlayers.isPlaying;
    }
}
