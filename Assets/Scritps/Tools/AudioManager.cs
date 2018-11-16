using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region 单例

    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioManager>();
            }

            return _instance;
        }
    }

    #endregion

    [Header("背景音乐")] private AudioSource backgroundAudioSource;
    [Header("特效音乐")] private AudioSource effectAudioSource;
    [Header("音频种类")] [SerializeField] private List<AudioType> allAudioTypes;
    [Header("音频种类")] [SerializeField] private Dictionary<AudioType.EAudioType, AudioClip> audioDlc;

    private void Awake()
    {
        Init();
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="audioType"></param>
    public void PlayEffectAudio(AudioType.EAudioType audioType)
    {
        foreach (AudioType type in allAudioTypes)
        {
            if (type.audioType == audioType)
            {
                effectAudioSource.PlayOneShot(type.audioClip, type.audioClip.length);
                return;
            }
        }
    }

    /// <summary>
    /// 暂停背景音乐播放
    /// </summary>
    public static void PauseBackgroundAudio()
    {
    }

    /// <summary>
    /// 开始背景音乐播放
    /// </summary>
    public static void PlayBackgroundAudio()
    {
    }

    /// <summary>
    /// 更换背景音乐
    /// </summary>
    public static void ChangeBackgroundAudio()
    {
        PlayBackgroundAudio();
    }

    private void Init()
    {
        audioDlc = new Dictionary<AudioType.EAudioType, AudioClip>();
        foreach (AudioType type in allAudioTypes)
        {
            if (!audioDlc.ContainsKey(type.audioType))
            {
                audioDlc.Add(type.audioType, type.audioClip);
            }
        }

        backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        effectAudioSource = gameObject.AddComponent<AudioSource>();
        AudioClip backgroundClip;
        audioDlc.TryGetValue(AudioType.EAudioType.EBackground, out backgroundClip);
        backgroundAudioSource.clip = backgroundClip;
        backgroundAudioSource.loop = true;
        effectAudioSource.playOnAwake = false;
        backgroundAudioSource.Play();
    }
}

[Serializable]
public class AudioType
{
    public enum EAudioType
    {
        EBackground,
        EClick,
        EOpen,
        EClose
    }

    public EAudioType audioType;
    public AudioClip audioClip;
}