using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image fillImage;

    private int maxHealth;

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        SetHealth(health);
    }

    public void SetHealth(int health)
    {
        if (fillImage != null)
            fillImage.fillAmount = (float)health / maxHealth;
    }
}
