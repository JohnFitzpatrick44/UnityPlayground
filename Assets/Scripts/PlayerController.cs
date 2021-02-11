using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
	[Range(0, 600)] [SerializeField] private float maxTurnSpeed = 400f;
	[Range(0, 50)] [SerializeField] private float maxThrustSpeed = 10f;
	[Range(0, 1)] [SerializeField] private float thrustTurnSpeedMultiplier = 0.3f;
	[Range(0, 100)] [SerializeField] private float thrustAcceleration = 10f;

	public Animator _animator;
	
	private Rigidbody2D _rigidbody2D;
	
	private static readonly int Thrust = Animator.StringToHash("Thrust");
	private static readonly int MaxSpeed = Animator.StringToHash("MaxSpeed");

	public void Awake()
    {
        this._rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void UpdatePlayer(float rotation, float thrust)
    {
	    this.Rotate(rotation, thrust > 0f);
	    this.Move(thrust);
    }

    private void Rotate(float rotation, bool isThrusting)
    {
	    var turnSpeedMultiplier = isThrusting ? thrustTurnSpeedMultiplier : 1f;
	    transform.Rotate(Vector3.forward * (-rotation * maxTurnSpeed * Time.deltaTime * turnSpeedMultiplier));
	    
	    this._animator.SetBool(Thrust, isThrusting);
    }

    private void Move(float thrust)
    {
	    var currentVelocity = this._rigidbody2D.velocity;
	    var acceleration = (Vector2) (thrust * thrustAcceleration * transform.up);

	    var newVelocity = (acceleration * Time.deltaTime) + currentVelocity;
	    if (newVelocity.magnitude > maxThrustSpeed)
	    {
		    newVelocity = newVelocity.normalized * maxThrustSpeed;
		    this._animator.SetBool(MaxSpeed, true);
	    }
	    else
	    {
		    this._animator.SetBool(MaxSpeed, false);
	    }

	    this._rigidbody2D.velocity = newVelocity;
    }
}
