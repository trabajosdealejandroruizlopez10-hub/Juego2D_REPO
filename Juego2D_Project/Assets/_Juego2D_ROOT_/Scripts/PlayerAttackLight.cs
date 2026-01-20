using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject swordHitbox; 
    [SerializeField] private Animator anim;          

    private bool isAttacking;

    void Awake()
    {
        if (anim == null)
            anim = GetComponent<Animator>();

        swordHitbox.SetActive(false);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && !isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true;
        anim.SetBool("isAttacking", true);
    }



    public void EnableSwordHitbox()
    {
        swordHitbox.SetActive(true);
    }

    public void DisableSwordHitbox()
    {
        swordHitbox.SetActive(false);
        EndAttack(); 
    }

    void EndAttack()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }
}
