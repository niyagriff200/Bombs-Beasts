using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private AudioSource musicSource;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        musicVolumeSlider.value = savedVolume;
        musicSource.volume = savedVolume;

        musicVolumeSlider.onValueChanged.AddListener(OnVolumeChanged);


        AudioSource[] allMusicSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        for (int i = 0; i < allMusicSources.Length; i++)
        {
            if (allMusicSources[i].clip == musicSource.clip)
            {
                allMusicSources[i].volume = savedVolume;
            }
        }

    }

    private void OnVolumeChanged(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }

    public void SettingsButton()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ShowSettingsScreen();
        }
    }
}
