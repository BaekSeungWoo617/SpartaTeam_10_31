using System;
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
    private float groundCheckDistance = 0.3f;
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private int _jumpCount = 0;
    private bool _isJumping = false;

    private float _time = 0.0f;

    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        // Get player component
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        if (_animator == null)
        {
            Debug.LogError("animator connot found!");
        }
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

        _animator.SetBool("IsRun", true);
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
            _jumpCount = 0;
        }

        if(context.phase == InputActionPhase.Started)
        {
            _jumpCount += 1;

            _animator.SetTrigger("Jump");
            _animator.SetInteger("JumpCount", _jumpCount);

            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
        }
    }

    public void OnSlide(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && CheckGround())
        {
            _animator.SetTrigger("Slide");
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
        Ray ray = new Ray(transform.position + transform.up * 0.1f, Vector3.down);
        return Physics.Raycast(ray, groundCheckDistance, groundLayer);
    }

    /* TestCode */
    // 장애물 트리거 시에 생명 줄고 소리나는 지 확인
    // private void OnTriggerEnter(Collider other)
    // {
    //     AudioManager.Instance.PlayCollsionSFX();
    //     GameManager.Instance.life--;
    // }
}
