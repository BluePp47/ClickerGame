using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource titleMusic;
    public AudioSource bgMusic;
    public AudioMixer mixer;
    public Slider bgmSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
      
        titleMusic.Play();  // 타이틀 음악 재생
        if (bgmSlider != null)
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
    }

    public void StartGame()
    {
        titleMusic.Stop();// 타이틀 음악 중지
        bgMusic.Play(); // 배경 음악 재생
    }

    public void SetBGMVolume(float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20;
        mixer.SetFloat("BGMVolume", volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
