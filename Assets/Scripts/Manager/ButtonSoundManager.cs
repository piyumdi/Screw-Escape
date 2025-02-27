using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    public AudioClip buttonClickSound;
    public AudioClip doorBreakSound;
    public Button[] buttons;

    private SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();

        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => PlaySound(buttonClickSound));
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (soundManager != null)
        {
            soundManager.PlaySound(clip);
        }
    }
}
