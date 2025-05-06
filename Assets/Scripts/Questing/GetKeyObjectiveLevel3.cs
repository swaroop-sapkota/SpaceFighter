using UnityEngine;
using UnityEngine.Video;

public class GetKeyObjectiveLevel3 : MonoBehaviour
{
    public GameObject GetKeyObj_Txt;
    public GameObject UseMaterial_Txt;
    public GameObject RunSpaceship_Txt;
    public VideoPlayer doorVideoPlayer;

    public static bool material1Found;
    public static bool material2Found;
    public static bool material3Found;
    public static bool material4Found;
    public static bool material5Found; 

    private bool hasPlayedVideo = false;

    void Start()
    {
        material1Found = false;
        material2Found = false;
        material3Found = false;
        material4Found = false;
        material5Found = false; 

        GetKeyObj_Txt.SetActive(false);
        UseMaterial_Txt.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool allMaterialsFound = material1Found && material2Found &&
                                     material3Found && material4Found &&
                                     material5Found; 

            if (!allMaterialsFound)
            {
                GetKeyObj_Txt.SetActive(true);
            }
            else if (allMaterialsFound && !hasPlayedVideo)
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
                            GameManager.instance.CompleteGame();
                        }
                    }
                }
                else
                {
                    UseMaterial_Txt.SetActive(false);
                    // Optionally show "Kill more dragons to activate!"
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
