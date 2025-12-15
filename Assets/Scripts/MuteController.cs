using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MuteController : MonoBehaviour
{
    [SerializeField] GameObject MuteButton;
    [SerializeField] AudioSource[] sounds;
    [SerializeField] VideoPlayer player;

    public int Mute { get; private set; } = 0; // 0 - false, 1 - true
    public void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Start")) return;

        if (PlayerPrefs.HasKey("Mute"))
            Mute = PlayerPrefs.GetInt("Mute");

        PlayerPrefs.SetInt("Mute", Mute);

        if (Mute == 0)
        {
            if (SceneManager.GetActiveScene().name.Equals("VideoScene"))
                player.SetDirectAudioMute(0, false);
            else
            {
                for (int i = 0; i < sounds.Length; i++)
                    sounds[i].mute = false;
            }

            if(MuteButton != null)
            {
                MuteButton.transform.GetChild(0).gameObject.SetActive(true);
                MuteButton.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        else
        {
            if (SceneManager.GetActiveScene().name.Equals("VideoScene"))
                player.SetDirectAudioMute(0, true);
            else
            {
                for (int i = 0; i < sounds.Length; i++)
                    sounds[i].mute = true;
            }

            if(MuteButton != null)
            {
                MuteButton.transform.GetChild(0).gameObject.SetActive(false);
                MuteButton.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    public void muteActivated()
    {
        Mute = 1;
        PlayerPrefs.SetInt("Mute", Mute);

        if (SceneManager.GetActiveScene().name.Equals("VideoScene"))
            player.SetDirectAudioMute(0, true);
        else
        {
            for (int i = 0; i < sounds.Length; i++)
                sounds[i].mute = true;

            if(MuteButton != null)
            {
                MuteButton.transform.GetChild(0).gameObject.SetActive(false);
                MuteButton.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
    public void muteDeactivated()
    {
        Mute = 0;
        PlayerPrefs.SetInt("Mute", Mute);

        if (SceneManager.GetActiveScene().name.Equals("VideoScene"))
            player.SetDirectAudioMute(0, false);
        else
        {
            for (int i = 0; i < sounds.Length; i++)
                sounds[i].mute = false;

            if (MuteButton != null)
            {
                MuteButton.transform.GetChild(0).gameObject.SetActive(true);
                MuteButton.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void toggleMute()
    {
        Mute = PlayerPrefs.GetInt("Mute");

        if (Mute == 0)
            muteActivated();
        else
            muteDeactivated();

        PlayerPrefs.SetInt("Mute", Mute);
    }
}
