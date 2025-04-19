using System;
using UnityEngine;

namespace _Main.Scripts
{
    public class PlayerController2D : MonoBehaviour
    {
        public bool isGrounded;

        [SerializeField] private AnimationHandler animationHandler;
        [SerializeField] private Transform rendererTransform;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpPower;
        [SerializeField] private float detectionDistance;

        private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _horizontal;
        private bool _isJumped;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("finish"))
            {
                UiManager.Instance.ShowGameSuccess();
            }
        }

        private void Update()
        {
            _horizontal = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                _isJumped = true;
            }

            if (_horizontal != 0)
            {
                animationHandler.PlayAnimation("isWalking");
            }
            else
            {
                animationHandler.StopAnimation("isWalking");
            }

            if (transform.position.y < -25)
            {
                UiManager.Instance.RemoveHeart();
                GameManager.Instance.SpawnAtSpawnPoint(this.transform);
            }
        }

        private void FixedUpdate()
        {
            GroundCheck();
            PlatformCheck();
            Move();

            if (_isJumped)
            {
                if (isGrounded)
                {
                    _rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                    _isJumped = false;
                }
            }
        }

        private void Move()
        {
            var horizontalMovement = new Vector2(_horizontal, 0).normalized;
            _rigidbody2D.velocity = new Vector2(horizontalMovement.x * movementSpeed, _rigidbody2D.velocity.y);
        }

        private void PlatformCheck()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rendererTransform.lossyScale.y + detectionDistance, LayerMask.GetMask("ground"));
            if (hit.collider != null)
            {
                if (hit.collider.tag == "platform")
                {
                    transform.SetParent(hit.collider.transform);
                }
            }
            else
            {
                transform.SetParent(null);
            }
        }

        private void GroundCheck()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rendererTransform.lossyScale.y + detectionDistance, LayerMask.GetMask("ground"));
            if (hit.collider != null)
            {
                animationHandler.StopAnimation("isJumping");
                isGrounded = true;
            }
            else
            {
                animationHandler.PlayAnimation("isJumping");
                isGrounded = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector2.down * (rendererTransform.lossyScale.y + detectionDistance));
        }
    }
}