using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic; 
    public AudioSource soundEffectsSource; 

    public Button[] musicButtons; 
    public Button[] soundButtons; 

    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
    public Sprite musicOnIcon;
    public Sprite musicOffIcon;

    private bool isMusicMuted;
    private bool isSoundMuted;

    void Start()
    {
        
        isMusicMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        isSoundMuted = PlayerPrefs.GetInt("SoundMuted", 0) == 1;

        UpdateMusicState();
        UpdateSoundState();

        
        foreach (Button musicBtn in musicButtons)
        {
            musicBtn.onClick.AddListener(ToggleMusic);
        }

        
        foreach (Button soundBtn in soundButtons)
        {
            soundBtn.onClick.AddListener(ToggleSound);
        }
    }

    
    public void ToggleMusic()
    {
        isMusicMuted = !isMusicMuted;
        PlayerPrefs.SetInt("MusicMuted", isMusicMuted ? 1 : 0);
        PlayerPrefs.Save();
        UpdateMusicState();
    }

    void UpdateMusicState()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.mute = isMusicMuted;
        }

        
        foreach (Button musicBtn in musicButtons)
        {
            if (musicBtn.image != null && musicOnIcon != null && musicOffIcon != null)
            {
                musicBtn.image.sprite = isMusicMuted ? musicOffIcon : musicOnIcon;
            }
        }
    }

    
    public void ToggleSound()
    {
        isSoundMuted = !isSoundMuted;
        PlayerPrefs.SetInt("SoundMuted", isSoundMuted ? 1 : 0);
        PlayerPrefs.Save();
        UpdateSoundState();
    }

    void UpdateSoundState()
    {
        if (soundEffectsSource != null)
        {
            soundEffectsSource.mute = isSoundMuted;
        }

        
        foreach (Button soundBtn in soundButtons)
        {
            if (soundBtn.image != null && soundOnIcon != null && soundOffIcon != null)
            {
                soundBtn.image.sprite = isSoundMuted ? soundOffIcon : soundOnIcon;
            }
        }
    }

    
    public void PlaySound(AudioClip clip)
    {
        if (!isSoundMuted && soundEffectsSource != null && clip != null)
        {
            soundEffectsSource.PlayOneShot(clip);
        }
    }
}
