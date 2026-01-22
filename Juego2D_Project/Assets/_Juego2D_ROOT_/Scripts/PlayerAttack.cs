using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack")]
    public GameObject swordHitbox;
    public float attackCooldown = 0.3f;

    private bool canAttack = true;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnAttack()
    {
        if (!canAttack) return;

        canAttack = false;

        if (anim != null)
            anim.SetTrigger("Attack");

        Invoke(nameof(ResetAttack), attackCooldown);
    }

    void ResetAttack()
    {
        canAttack = true;
    }

    // LLAMADAS DESDE ANIMATION EVENT
    public void EnableHitbox()
    {
        swordHitbox.SetActive(true);
    }

    public void DisableHitbox()
    {
        swordHitbox.SetActive(false);
    }
}
