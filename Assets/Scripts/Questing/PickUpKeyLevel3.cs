using UnityEngine;

public class PickUpKeyLevel3 : MonoBehaviour
{
    public enum MaterialType { Material1, Material2, Material3, Material4, Material5 }
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
                PickMaterial_Txt.SetActive(false);

                switch (materialType)
                {
                    case MaterialType.Material1:
                        GetKeyObjectiveLevel3.material1Found = true;
                        break;
                    case MaterialType.Material2:
                        GetKeyObjectiveLevel3.material2Found = true;
                        break;
                    case MaterialType.Material3:
                        GetKeyObjectiveLevel3.material3Found = true;
                        break;
                    case MaterialType.Material4:
                        GetKeyObjectiveLevel3.material4Found = true;
                        break;
                    case MaterialType.Material5: 
                        GetKeyObjectiveLevel3.material5Found = true;
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