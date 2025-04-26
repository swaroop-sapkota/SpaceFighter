using UnityEngine;
using UnityEngine.Video;

public class GetKeyObjective : MonoBehaviour
{
    public GameObject GetKeyObj_Txt;
    public GameObject UseMaterial_Txt;
    public GameObject RunSpaceship_Txt;
    public VideoPlayer doorVideoPlayer;

    public static bool isFound;

    private bool hasPlayedVideo = false;

    void Start()
    {
        isFound = false;
        GetKeyObj_Txt.SetActive(false);
        UseMaterial_Txt.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isFound)
            {
                GetKeyObj_Txt.SetActive(true);
            }
            else if (isFound && !hasPlayedVideo)
            {
                UseMaterial_Txt.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    RunSpaceship_Txt.SetActive(false);
                    GetKeyObj_Txt.SetActive(false);
                    UseMaterial_Txt.SetActive(false);

                    hasPlayedVideo = true;

                    if (doorVideoPlayer != null)
                    {
                        doorVideoPlayer.Play();
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetKeyObj_Txt.SetActive(false);
            UseMaterial_Txt.SetActive(false);
        }
    }
}
