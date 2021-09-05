using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public static float masterVolumeSFX = 1f;
    public static float masterVolumeBGM = 0.3f;

    [SerializeField] AudioClip BGMClip;
    [SerializeField] AudioClip[] clips;

    AudioSource sfxPlayer;
    AudioSource bgmPlayer;

    void Awake()
    {
        instance = this;

        sfxPlayer = GetComponent<AudioSource>();
        SetUpBGM();
        if (bgmPlayer != null)
            bgmPlayer.Play();
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sfxPlayer.volume = masterVolumeSFX;
        bgmPlayer.volume = masterVolumeBGM;
    }

    void SetUpBGM()
    {
        if (BGMClip == null) return;

        GameObject child = new GameObject("BGM");
        child.transform.SetParent(transform);
        bgmPlayer = child.AddComponent<AudioSource>();
        bgmPlayer.clip = BGMClip;
        bgmPlayer.loop = true;
        bgmPlayer.volume = masterVolumeBGM;
    }

    public void ButtonClick()
    {
        sfxPlayer.clip = clips[0];
        sfxPlayer.Play();
    }

    public void PlayerAttack()
    {
        sfxPlayer.PlayOneShot(clips[1]);
    }
    public void PlayerDamaged()
    {
        sfxPlayer.PlayOneShot(clips[2]);
    }
    public void PlayerWalk()
    {
        sfxPlayer.PlayOneShot(clips[3]);
    }
}
