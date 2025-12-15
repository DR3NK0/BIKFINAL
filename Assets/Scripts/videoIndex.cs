using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class videoIndex : MonoBehaviour
{
    [SerializeField] VideoPlayer videoController;

    [SerializeField] SceneController sceneController;

    [SerializeField] GameObject skipButton;

    static int videoPlayingIndex = 0;

    public void setVideoPlayingIndex(int vIndex) => videoPlayingIndex = vIndex;

    void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals("VideoScene")) return;

        videoController.loopPointReached += OnVideoEnd;

        string url = "";

        skipButton.SetActive(false);

        if (videoPlayingIndex == 1)
        {
            url = System.IO.Path.Combine(Application.streamingAssetsPath, "INTRO.mp4");
            skipButton.SetActive(true);
        }
        else if(videoPlayingIndex == 3 || videoPlayingIndex == 4 || videoPlayingIndex == 5)
            url = System.IO.Path.Combine(Application.streamingAssetsPath, "TRANSITION.mp4");
        else if (videoPlayingIndex == 6)
            url = System.IO.Path.Combine(Application.streamingAssetsPath, "OUTRO.mp4");

        videoController.url = url;
        videoController.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (videoPlayingIndex == 1)
            sceneController.loadScene("Menu");
        else if (videoPlayingIndex == 3)
            sceneController.loadScene("Game3");
        else if (videoPlayingIndex == 4)
            sceneController.loadScene("Game4");
        else if(videoPlayingIndex == 5)
            sceneController.loadScene("Game5");
        else if (videoPlayingIndex == 6)
            sceneController.loadScene("Start");
    }
}
