using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject swordHitbox;
    public int damage = 25;
    public float attackDuration = 0.3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        swordHitbox.SetActive(true);
        Invoke(nameof(StopAttack), attackDuration);
    }

    void StopAttack()
    {
        swordHitbox.SetActive(false);
    }

}
