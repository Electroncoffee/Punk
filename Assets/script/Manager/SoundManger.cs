using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;



public class SoundManger : MonoBehaviour
{
    public static SoundManger instance;

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    public AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    public AudioSource[] sfxPlayers;
    public int channelIndex;

    public enum Sfx { Start, GameOver, Move, Jump, land, Interact, Dameged }

    void Awake()
    {
        instance = this; //메모리에 사운드 매니저를 할당
        Init(); //초기화 함수
    }
    void Init()
    {
        // 배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;


        // 효과음 플레이어 초기화
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for(int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].volume = sfxVolume;
        }
        PlayBgm();
    }
    void PlayBgm()
    {
        bgmPlayer.Play();
    }
    void StopBgm()
    {
        bgmPlayer.Stop();
    }
    void UpdateBgmVolume(float volume)
    {
        bgmPlayer.volume = volume;
    }
    void UpdateSfxVolume(float volume)
    {
        sfxPlayers[0].volume = volume;
    }
    void PlaySfx(Sfx sfx)
    {
        //사용형식
        //SoundManger.instance.PlaySfx(SoundManger.Sfx.Start); == 시작 버튼 효과음 재생
        for(int i =0; i < sfxPlayers.Length; i++)
        {
            int loopIndex = (i + channelIndex) % sfxPlayers.Length;
            if(sfxPlayers[loopIndex].isPlaying)
                continue;
            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;

        }
    }
}
