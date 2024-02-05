using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    public float brakeSpeed = 2.0f; // Adjust this value to control braking intensity
    

    private Rigidbody2D _rigidbody;
    private bool _thrusting;
    private float _turnDirection;
    private bool _braking;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _thrusting = Input.GetKey(KeyCode.W);
        _braking = Input.GetKey(KeyCode.S);// Detect S key for braking

        if (Input.GetKey(KeyCode.A))
        {
            _turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _turnDirection = -1.0f;
        }
        else
        {
            _turnDirection = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        if (_thrusting)
        {
            _rigidbody.AddForce(transform.up * thrustSpeed);
        }

        if (_turnDirection != 0.0f)
        {
            _rigidbody.AddTorque(_turnDirection * turnSpeed);
        }

        if (_braking)
        {
            // Apply braking force to slow down the player's movement
            _rigidbody.velocity *= Mathf.Pow(brakeSpeed, Time.fixedDeltaTime);
            _rigidbody.angularVelocity *= Mathf.Pow(brakeSpeed, Time.fixedDeltaTime);
        }
    }
}




