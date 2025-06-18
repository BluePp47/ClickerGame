using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource titleMusic;
    public AudioSource bgMusic;

    public AudioMixer mixer;
    public Slider bgmSlider;

    private void Awake()
    {
        // 현재 씬 이름 확인
        string currentScene = SceneManager.GetActiveScene().name;

        // 인트로 씬에서는 AudioManager 유지하지 않음
        if (currentScene == "IntroScene") // 인트로 씬 이름 정확히 넣기!
        {
            // 인트로 씬에선 그냥 둠 (DontDestroyOnLoad 사용 안함)
            return;
        }

        // 나머지 씬에서는 싱글톤 패턴 사용
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else Destroy(gameObject);
        //return;
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
        TryFindSliderAndConnect();
        LoadBGMVolume();

        if (bgmSlider == null)
        {
            // 이름으로 슬라이더를 찾아 연결 (씬마다 있어야 할 경우)
            bgmSlider = GameObject.Find("BGMSlider")?.GetComponent<Slider>();
            if (bgmSlider != null)
            {
                bgmSlider.onValueChanged.AddListener(SetBGMVolume);
            }
        }

        // 슬라이더 값 불러오기 및 볼륨 세팅
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            float volume = PlayerPrefs.GetFloat("BGMVolume");
            SetBGMVolume(volume);
            if (bgmSlider != null) bgmSlider.value = volume;
        }



        titleMusic.Stop();// 타이틀 음악 중지
        bgMusic.Play(); // 배경 음악 재생
    }
    void TryFindSliderAndConnect()
    {
        if (bgmSlider == null)
        {
            GameObject sliderObj = GameObject.Find("BGMSlider");
            if (sliderObj != null)
            {
                bgmSlider = sliderObj.GetComponent<Slider>();
                bgmSlider.onValueChanged.AddListener(SetBGMVolume);
            }
        }
    }


    public void SetBGMVolume(float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20;
        mixer.SetFloat("BGMVolume", volume);
    }

    void LoadBGMVolume()
    {
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            float volume = PlayerPrefs.GetFloat("BGMVolume");
            SetBGMVolume(volume);
            if (bgmSlider != null)
            {
                bgmSlider.value = volume;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
