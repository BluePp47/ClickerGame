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
        // ���� �� �̸� Ȯ��
        string currentScene = SceneManager.GetActiveScene().name;

        // ��Ʈ�� �������� AudioManager �������� ����
        if (currentScene == "IntroScene") // ��Ʈ�� �� �̸� ��Ȯ�� �ֱ�!
        {
            // ��Ʈ�� ������ �׳� �� (DontDestroyOnLoad ��� ����)
            return;
        }

        // ������ �������� �̱��� ���� ���
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
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
        titleMusic.Play();  // Ÿ��Ʋ ���� ���
        if (bgmSlider != null)
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);

    }



    public void StartGame()
    {
        TryFindSliderAndConnect();
        LoadBGMVolume();

        if (bgmSlider == null)
        {
            // �̸����� �����̴��� ã�� ���� (������ �־�� �� ���)
            bgmSlider = GameObject.Find("BGMSlider")?.GetComponent<Slider>();
            if (bgmSlider != null)
            {
                bgmSlider.onValueChanged.AddListener(SetBGMVolume);
            }
        }

        // �����̴� �� �ҷ����� �� ���� ����
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            float volume = PlayerPrefs.GetFloat("BGMVolume");
            SetBGMVolume(volume);
            if (bgmSlider != null) bgmSlider.value = volume;
        }



        titleMusic.Stop();// Ÿ��Ʋ ���� ����
        bgMusic.Play(); // ��� ���� ���
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
