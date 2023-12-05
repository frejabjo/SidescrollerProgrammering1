using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum CharacterState
{
    Grounded = 0,
    Airborne = 1, 
    Jumping = 2,
    
    Total 
}
public class MovementController : MonoBehaviour
{
    public CharacterState JumpingState = CharacterState.Airborne;

    //Gravity
    public float GravitySpeed = 10.0f;
    public float GroundLevel = 0.0f;

    //Jump
    public float JumpSpeedFactor = 2.0f;
    public float JumpMaxHeight = 4.0f;
    public float JumpHeightDelta = 0.0f;
    
    //Movement
    public float MovementSpeed = 10.0f;

    void Update()

    {
        if (transform.position.y <= GroundLevel)
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y = GroundLevel;
            transform.position = characterPosition;

            JumpingState = CharacterState.Grounded;
        }

        //Up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;
        }

        if (JumpingState == CharacterState.Jumping)
        {
            Vector3 characterPosition = transform.position;
            float totalJumpMovementSpeedThisFrame = MovementSpeed * JumpSpeedFactor * Time.deltaTime;
            characterPosition.y += totalJumpMovementSpeedThisFrame;
            transform.position = characterPosition;
            JumpHeightDelta += totalJumpMovementSpeedThisFrame;
            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
            }
        }


        //Down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y -= MovementSpeed * Time.deltaTime;
            transform.position = characterPosition;
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x -= MovementSpeed * Time.deltaTime;
            transform.position = characterPosition;
        }

        //Right
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x += MovementSpeed * Time.deltaTime;
            transform.position = characterPosition;
        }

    
        if (JumpingState == CharacterState.Airborne)
        {
            Vector3 gravityPosition = transform.position;
            gravityPosition.y -= GravitySpeed * Time.deltaTime;
            if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; }
            transform.position = gravityPosition;
        }
    }
}
