using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetFloat("speed", 0f);
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            animator.SetTrigger("jump");
        }
    }
}
