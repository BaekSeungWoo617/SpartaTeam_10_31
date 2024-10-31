using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    private Vector2 _moveInput = Vector2.zero;
    [SerializeField] private float _verticalSpeed = 3.0f;
    [SerializeField] private float _horizontalSpeed = 3.0f;
    private float _increaseSpeed;

    [Header("Jump")]
    private LayerMask groundLayer;
    private float groundCheckDistance = 0.6f;
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private bool _extraJump = true;

    private float _time = 0.0f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        // Get rigidbody component
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _increaseSpeed = _verticalSpeed;

        // Ground Layer set
        groundLayer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if(_time > 10.0f)
        {
            _increaseSpeed *= 1.05f;
            _time = 0.0f;
            Debug.Log(_increaseSpeed);
        }
    }

    private void FixedUpdate()
    {
        // Movement physics operation
        ApplyMove();
    }

    private void LateUpdate()
    {
        // Camera operation
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            _moveInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            _moveInput = Vector2.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (CheckGround())
        {
            _extraJump = true;
        }

        if(context.phase == InputActionPhase.Started && _extraJump)
        {
            _extraJump = false;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void ApplyMove()
    {
        Vector3 moveVector = transform.forward * _increaseSpeed + transform.right * _moveInput.x * _horizontalSpeed;
        moveVector.y = _rigidbody.velocity.y;
        _rigidbody.velocity = moveVector;
    }

    private bool CheckGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        RaycastHit hit;

        return Physics.Raycast(ray, out hit, groundCheckDistance, groundLayer);
    }
}
