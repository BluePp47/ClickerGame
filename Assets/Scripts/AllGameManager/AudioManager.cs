using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource titleMusic;
    public AudioSource bgMusic;

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
    }

    public void StartGame()
    {
        titleMusic.Stop();// 타이틀 음악 중지
        bgMusic.Play(); // 배경 음악 재생
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
