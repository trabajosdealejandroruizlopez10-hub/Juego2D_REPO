using UnityEngine;

public class PlayerAttackHeavy : MonoBehaviour
{
    [SerializeField] private GameObject hitbox;
    [SerializeField] private float duration = 0.35f;

    public void DoAttack()
    {
        hitbox.SetActive(true);
        Invoke(nameof(DisableHitbox), duration);
    }

    private void DisableHitbox()
    {
        hitbox.SetActive(false);
    }
}
