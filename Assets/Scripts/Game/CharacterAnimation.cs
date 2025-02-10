using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartJumping()
    {
        animator.SetTrigger("Jump");  // Trigger the jump animation
    }
}
