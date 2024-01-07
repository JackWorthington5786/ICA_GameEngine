using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    [SerializeField]
    private Image background;

    public void HandleButtonClick()
    {
        Debug.Log($"clicked");
    }

    public void HandlePickup(int amount)
    {
        amount /= 100;
        background.fillAmount += amount;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            background.fillAmount += 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            background.fillAmount -= 0.1f;
        }
    }
}