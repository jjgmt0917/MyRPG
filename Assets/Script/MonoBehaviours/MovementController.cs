
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    Rigidbody2D rb2D;

    Animator animator;
    string animationState = "AnimationState";
    enum CharStates
    {
        walk = 1,
        attack = 2,
        dead = 3,
        idle = 4
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Rotate()
    {

    }
    void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }
    // Update is called once per frame
    private void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void UpdateState()
    {
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetInteger(animationState, (int)CharStates.walk);
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetInteger(animationState, (int)CharStates.walk);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walk);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walk);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.idle);
        }
    }
}
