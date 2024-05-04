using TMPro;
using UnityEngine;

public class UIPartsCounter : MonoBehaviour
{
    private TextMeshProUGUI TMPro;

    private void Start()
    {
        TMPro = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        TMPro.text = MiniGameManager.Parts.ToString();
    }
}
