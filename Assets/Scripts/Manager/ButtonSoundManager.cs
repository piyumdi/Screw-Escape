using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    public AudioSource audioSource;  // Reference to the AudioSource
    public AudioClip buttonClickSound; // Button click sound
    public AudioClip doorBreakSound; // Door breaking sound
    public Button[] buttons; // Array to hold buttons

    void Start()
    {
        // Assign click event to all buttons in the array
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => PlaySound(buttonClickSound));
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
