using System.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class InputJump : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    private Rigidbody2D playerRb;
    private PlayerInput playerInput;
    private InputAction touchTap;
    [SerializeField] float force;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchTap = playerInput.actions["Press"];
        playerRb = player != null ? player.GetComponent<Rigidbody2D>() : null;
    }

    private void OnEnable()
    {
        touchTap.performed += OnTouchTap;
    }

    private void OnDisable()
    {
        touchTap.performed -= OnTouchTap;
    }

    private void OnDestroy()
    {
        touchTap.performed -= OnTouchTap;
    }

    private void OnTouchTap(InputAction.CallbackContext context)
    {
        if (player == null || animator == null || playerRb == null) return; // защита от MissingReferenceException
        SoundLogic.instance.PlaySfx("SwingSfx");
        animator.SetBool("IsSwings", true);
        
        bool tapp = context.ReadValueAsButton();
        AddForce(tapp);
        StartCoroutine(WaitForSwing());
    }

    private void AddForce(bool tapp)
    {
        playerRb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    IEnumerator WaitForSwing()
    {
        yield return new WaitForSeconds(0.1f);
        if (animator != null)
            animator.SetBool("IsSwings", false);
    }
}
