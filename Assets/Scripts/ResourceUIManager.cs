using UnityEngine;
using TMPro;

public class ResourceUIManager : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI treeText;
    public TextMeshProUGUI electricityText;

    private int goldCount = 0;
    private int treeCount = 0;
    private int electricityCount = 0;

    // Обновление текста ресурсов
    public void UpdateGold()
    {
        goldCount += 10;
        goldText.text = "Gold: " + goldCount;
    }

    public void UpdateTree()
    {
        treeCount += 10;
        treeText.text = "Tree: " + treeCount;
    }

    public void UpdateElectricity()
    {
        electricityCount += 10;
        electricityText.text = "Electricity: " + electricityCount;
    }
}
