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
      
        titleMusic.Play();  // Ÿ��Ʋ ���� ���
    }

    public void StartGame()
    {
        titleMusic.Stop();// Ÿ��Ʋ ���� ����
        bgMusic.Play(); // ��� ���� ���
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
