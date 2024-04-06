using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Input for attack
        if (Input.GetKeyDown(KeyCode.G) && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
        }

        // Check if the animation is still playing
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AttackAnimationName") && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            // If attack animation is playing, don't allow movement or other actions
            return;
        }
        else
        {
            isAttacking = false; // Reset the attack status
        }

    }
}