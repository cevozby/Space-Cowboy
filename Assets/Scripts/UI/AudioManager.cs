using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer backgroundMixer;
    [SerializeField] AudioMixer enviromentMixer;

    [SerializeField] Slider backgroundSlider, environmentSlider;

    [SerializeField] AudioSource environmentSource;

    AudioManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StopAudio();
        if (PlayerPrefs.HasKey("BackgroundVolume"))
        {
            backgroundSlider.value = PlayerPrefs.GetFloat("BackgroundVolume");
            backgroundMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("BackgroundVolume"));
        }

        if (PlayerPrefs.HasKey("EnvironmentVolume"))
        {
            backgroundSlider.value = PlayerPrefs.GetFloat("EnvironmentVolume");
            backgroundMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("EnvironmentVolume"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackgroundVolume(float volume)
    {
        backgroundMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("BackgroundVolume", volume);
    }

    public void EnviromentVolume(float volume)
    {
        enviromentMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("EnvironmentVolume", volume);
    }

    public void PlayAudio(AudioClip clip)
    {
        if (environmentSource.isPlaying)
        {
            environmentSource.Stop();
            environmentSource.clip = clip;
            environmentSource.Play();
        }
        else
        {
            environmentSource.clip = clip;
            environmentSource.Play();
        }
    }

    public void StopAudio()
    {
        if (environmentSource.isPlaying)
        {
            environmentSource.Stop();
            environmentSource.clip = null;
        }
    }

}
