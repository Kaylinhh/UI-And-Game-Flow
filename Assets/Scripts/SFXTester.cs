using UnityEngine;
using UnityEngine.UI;

public class SFXTester : MonoBehaviour
{
    public Button testSFXButton;
    public AudioClip sfxSource;

    void Start()
    {
        testSFXButton.onClick.AddListener(() =>
        {
            AudioManager.instance.PlaySFX(sfxSource);
        });
    }

    public void PlaySFX()
    {
        AudioManager.instance.PlaySFX(sfxSource);

    }
}
