using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CutsceneManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject videoCanvas;
    public GameObject levelsUI;

    public VideoPlayer videoPlayer;

    void Start()
    {
        // Make sure only Main Menu is active at start
        mainMenuUI.SetActive(true);
        videoCanvas.SetActive(false);
        levelsUI.SetActive(false);
    }

    public void OnPlayClicked()
    {
        mainMenuUI.SetActive(false);
        videoCanvas.SetActive(true);
        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        videoCanvas.SetActive(false);
        levelsUI.SetActive(true);
    }

    public void SkipVideo()
    {
        videoPlayer.Stop();
        videoCanvas.SetActive(false);
        levelsUI.SetActive(true);
    }
}
