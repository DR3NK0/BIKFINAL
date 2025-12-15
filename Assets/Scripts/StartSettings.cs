using UnityEngine;
using UnityEngine.UI;

public class StartSettings : MonoBehaviour
{
    [SerializeField] MuteController muteController;

    int selectedLanguage = 0; // 0 - Macedonian, 1 - English, 2 - Shqip

    [SerializeField] GameObject[] LanguageButtons;
    [SerializeField] GameObject[] LanguageGameObjects; // 0 - Macedonian, 1 - English, 2 - Shqip

    void Start()
    {
        int Mute = 0;

        if (PlayerPrefs.HasKey("Mute"))
            Mute = PlayerPrefs.GetInt("Mute");

        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Mute", Mute);

        muteController.Start();

        startLoadingLanguage();
    }

    public void startLoadingLanguage()
    {
        if (PlayerPrefs.HasKey("Language"))
            selectedLanguage = PlayerPrefs.GetInt("Language");
        else
        {
            selectedLanguage = 0;
            PlayerPrefs.SetInt("Language", 0);
        }

        switchLanguage();
        switchLanguageButtons();
    }

    public void switchLanguageButtons()
    {
        for (int i = 0; i < LanguageButtons.Length; i++)
            LanguageButtons[i].GetComponent<Button>().interactable = true;

        LanguageButtons[selectedLanguage].GetComponent<Button>().interactable = false;
    }

    public void switchLanguage()
    {
        for (int i = 0; i < LanguageGameObjects.Length; i++)
            LanguageGameObjects[i].SetActive(false);

        LanguageGameObjects[selectedLanguage].SetActive(true);
    }

    public void switchLanguage(int index)
    {
        selectedLanguage = index;
        PlayerPrefs.SetInt("Language", selectedLanguage);

        switchLanguageButtons();
        switchLanguageButtons();
    }
}
