using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float gravity = -15f;
    public float runSpeed = 8f;

    // Animation states
    private int idleState = Animator.StringToHash("Base Layer.Idle");
    private int runState = Animator.StringToHash("Base Layer.Run");
    private int jumpState = Animator.StringToHash("Base Layer.Jump");

    private CharacterController2D _controller;
    private Animator _animator;

	void Awake()
    {
        _controller = GetComponent<CharacterController2D>();
        _animator = GetComponent<Animator>();

        
    }

    void Update()
    {
        
        // grab our current velocity to use as the base for all calculations
        var velocity = _controller.velocity;

        if (_controller.isGrounded)
            velocity.y = 0;

        // horizontal input
        if(Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = runSpeed;
            goRight();

            if (_controller.isGrounded)
                _animator.goToStateIfNotAlreadyThere(runState);

        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -runSpeed;
            goLeft();

            if (_controller.isGrounded)
                _animator.goToStateIfNotAlreadyThere(runState);

        }
        else
        {
            velocity.x = 0;

            if (_controller.isGrounded)
                _animator.goToStateIfNotAlreadyThere(idleState);
        }
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            var targetJumpHeight = 2f;
            velocity.y = Mathf.Sqrt(2f * targetJumpHeight * -gravity);
            _animator.goToStateIfNotAlreadyThere(jumpState);

        }

        // apply gravity before moving
        velocity.y += gravity * Time.deltaTime;
        _controller.move(velocity * Time.deltaTime);
           
        }

    private void goLeft()
    {
        if (transform.localScale.x > 0f)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void goRight()
    {
        if (transform.localScale.x < 0f)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }


    
}
