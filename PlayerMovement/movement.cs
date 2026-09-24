using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform PlayerCam;
    private float wHoldTimer = 0f;
    private bool HoldW = false;
    private Rigidbody rb;
    private Animator anim;
    [SerializeField] private InputRead inputReader;
    private Vector2 MoveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = PlayerCam.GetComponent<Animator>();
        anim.Play("CamWalk");
        anim.speed = 0f;
    }
    private void OnEnable()
    {
        inputReader.ReadMoveStarted += OnMovePerformed;
        inputReader.ReadMoveCanceled += OnMoveCanceled;
    }
    private void OnDisable()
    {
        inputReader.ReadMoveStarted -= OnMovePerformed;
        inputReader.ReadMoveCanceled -= OnMoveCanceled;
    }

    private void OnMovePerformed(Vector2 input)
    {
        MoveInput = input;
        HoldW = true;
    }

    private void OnMoveCanceled()
    {
        HoldW = false;
        MoveInput = Vector2.zero;
        wHoldTimer = 0f;
        anim.speed = 0f;
        speed = 3f;
    }

    void FixedUpdate()
    {
        if (HoldW)
        {
            wHoldTimer += Time.fixedDeltaTime;

            if (wHoldTimer > 5f)
            {
                // Fast sprint - maximum bobbing and maximum speed
                anim.speed = 3f;
                speed = 6f;
            }
            else if (wHoldTimer > 3f)
            {
                // Slow sprint: medium bobbing and medium speed
                anim.speed = 2f;
                speed = 4.5f;
            }
            else // if button pressed less then 3 seconds 
            {
                // Default walk: light bobbing and normal speed
                anim.speed = 1f;
                speed = 3f;
            }
        }
        Vector3 globalDirection = transform.TransformDirection(new Vector3(MoveInput.x, 0, MoveInput.y));
        rb.linearVelocity = new Vector3(globalDirection.x * speed, rb.linearVelocity.y, globalDirection.z * speed);
    }
}