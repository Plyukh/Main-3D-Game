using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private WeaponManager weaponManager;
    private CharacterController character_Controller;
    private OpenUI openUI;

    private Vector3 move_Direction;

    public float speed;
    public float gravity = 15f;

    public float jump_Forse = 5f;
    private float vertital_Velocity;

    public Vector3 MoveDirection
    {
        get
        {
            return move_Direction;
        }
    }

    void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
        weaponManager = GetComponent<WeaponManager>();
        openUI = GetComponent<OpenUI>();
    }

    void Update()
    {
        MoveThePlayer();
    }

    void MoveThePlayer()
    {
        move_Direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move_Direction = transform.TransformDirection(move_Direction);

        if (openUI.InventoryOpen())
        {
            move_Direction *= GetComponent<PlayerSprintAndCrouch>().idle_Speed * Time.deltaTime;
            GetComponent<PlayerSprintAndCrouch>().Move();
        }
        else
        {
            move_Direction *= speed * Time.deltaTime;
        }

        ApplyGravity();

        character_Controller.Move(move_Direction);

        if(weaponManager.GetCurrentSelectedWeapon() != null)
        {
            if (weaponManager.GetCurrentSelectedWeapon().gameObject.activeInHierarchy)
            {
                if (move_Direction.x != 0)
                {
                    if(speed == GetComponent<PlayerSprintAndCrouch>().move_Speed)
                    {
                        weaponManager.GetCurrentSelectedWeapon().WalkAnimation();
                    }

                    else if (speed == GetComponent<PlayerSprintAndCrouch>().sprint_Speed)
                    {
                        weaponManager.GetCurrentSelectedWeapon().RunAnimation();
                    }
                }
                else
                {
                    weaponManager.GetCurrentSelectedWeapon().IdleAnimation();
                }
            }
        }
    }

    void ApplyGravity()
    {
        if (character_Controller.isGrounded)
        {
            vertital_Velocity -= gravity * Time.deltaTime;

            PlayerJump();
        }

        else
        {
            vertital_Velocity -= gravity * Time.deltaTime;
        }

        move_Direction.y = vertital_Velocity * Time.deltaTime;
    }

    void PlayerJump()
    {
        if(character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space) && !openUI.InventoryOpen())
        {
            vertital_Velocity = jump_Forse;
        }
    }
}
