using UnityEngine;

public class PlayerStyler : MonoBehaviour
{
    [SerializeField] private Material baseMaterial;

    private void Start()
    {
        SetBaseMaterialColor(new Color32(255,255,255,255));
    }

    public void SetBaseMaterialColor(Color32 newColor)
    {
        baseMaterial.color = newColor;
    }
}
