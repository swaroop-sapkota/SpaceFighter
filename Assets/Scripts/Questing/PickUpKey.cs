using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public enum MaterialType { Material1, Material2, Material3 }
    public MaterialType materialType;

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

                // Set the correct material based on what this pickup is
                switch (materialType)
                {
                    case MaterialType.Material1:
                        GetKeyObjective.material1Found = true;
                        break;
                    case MaterialType.Material2:
                        GetKeyObjective.material2Found = true;
                        break;
                    case MaterialType.Material3:
                        GetKeyObjective.material3Found = true;
                        break;
                }
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
