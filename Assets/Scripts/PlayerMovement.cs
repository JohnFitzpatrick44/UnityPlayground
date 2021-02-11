using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;

    private float _rotation = 0f;
    private float _thrust = 0f;

    // TODO implement controller
    public void Update()
    {
        // TODO implement own movement smoothing
        this._rotation = Input.GetAxis("Horizontal");
        
        var verticalInput = Input.GetAxisRaw("Vertical");
        this._thrust = verticalInput > 0f ? verticalInput : 0f;
    }

    public void FixedUpdate()
    {
        this.controller.UpdatePlayer(this._rotation, this._thrust);
    }
}
