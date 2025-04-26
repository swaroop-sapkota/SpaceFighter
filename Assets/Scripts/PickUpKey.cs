using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject Key;
    public GameObject GetKeyObj_Txt;
    public GameObject RunSpaceship_Txt;
    public GameObject PickMaterial_Txt;

    private void Start()
    {
        RunSpaceship_Txt.SetActive(false);
        PickMaterial_Txt.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickMaterial_Txt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Key.SetActive(false);
                GetKeyObj_Txt.SetActive(false);
                RunSpaceship_Txt.SetActive(true);
                PickMaterial_Txt.SetActive(false);

                GetKeyObjective.isFound = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickMaterial_Txt.SetActive(false);
        }
    }
}
