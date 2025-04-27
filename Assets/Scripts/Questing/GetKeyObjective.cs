using UnityEngine;
using UnityEngine.Video;

public class GetKeyObjective : MonoBehaviour
{
    public GameObject GetKeyObj_Txt;
    public GameObject UseMaterial_Txt;
    public GameObject RunSpaceship_Txt;
    public VideoPlayer doorVideoPlayer;

    public static bool material1Found;
    public static bool material2Found;
    public static bool material3Found;

    private bool hasPlayedVideo = false;

    void Start()
    {
        material1Found = false;
        material2Found = false;
        material3Found = false;

        GetKeyObj_Txt.SetActive(false);
        UseMaterial_Txt.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!(material1Found && material2Found && material3Found))
            {
                GetKeyObj_Txt.SetActive(true);
            }
            else if (material1Found && material2Found && material3Found && !hasPlayedVideo)
            {
                if (EnemyKillTracker.HasKilledEnough())
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
                else
                {
                    UseMaterial_Txt.SetActive(false);
                    RunSpaceship_Txt.SetActive(true); // Show "Kill more dragons to activate!"
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
