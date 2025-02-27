using UnityEngine;
using TMPro;  // Import for TextMeshPro support

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public TextMeshProUGUI coinText;
    private int coins = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coinText.text = coins.ToString();
    }
}
