using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintAndCrouch : MonoBehaviour
{
    public float sprint_Speed_Base = 10f;
    public float move_Speed_Base = 5f;
    public float crouch_Speed_Base = 2f;

    public float sprint_Speed;
    public float move_Speed;
    public float crouch_Speed;
    public float idle_Speed;

    private Transform look_Root;
    private float stand_Height = 1.6f;
    private float crouch_Height = 0.8f;

    private bool is_Crouching;

    private PlayerFootsteps player_Footsteps;

    private float sprint_Volume = 1f;
    private float crouch_Volume = 0.1f;
    private float walk_Volume_Min = 0.2f, walk_Volume_Max = 0.6f;

    private float walk_Step_Distance = 0.4f;
    private float sprint_Step_Distance = 0.25f;
    private float crouch_Step_Distance = 0.5f;

    void Awake()
    {
        look_Root = transform.GetChild(0);

        player_Footsteps = GetComponentInChildren<PlayerFootsteps>();
    }
    // Start is called before the first frame update
    void Start()
    {
        sprint_Speed = sprint_Speed_Base;
        move_Speed = move_Speed_Base;
        crouch_Speed = crouch_Speed_Base;

        player_Footsteps.volume_Min = walk_Volume_Min;
        player_Footsteps.volume_Max = walk_Volume_Max;
        player_Footsteps.steep_Distance = walk_Step_Distance;
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching && GetComponent<PlayerMovement>().MoveDirection.x != 0)
        {
            if (GetComponent<WeaponManager>().GetCurrentSelectedWeapon() == null ||
                GetComponent<WeaponManager>().GetCurrentSelectedWeapon().Holster() ||
                GetComponent<WeaponManager>().GetCurrentSelectedWeapon().CanAttack())
            {
                GetComponent<PlayerMovement>().speed = sprint_Speed;

                player_Footsteps.steep_Distance = sprint_Step_Distance;
                player_Footsteps.volume_Min = sprint_Volume;
                player_Footsteps.volume_Max = sprint_Volume;
            }
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            Move();
        }
    }

    public void Move()
    {
        GetComponent<PlayerMovement>().speed = move_Speed;

        player_Footsteps.volume_Min = walk_Volume_Min;
        player_Footsteps.volume_Max = walk_Volume_Max;
        player_Footsteps.steep_Distance = walk_Step_Distance;

        look_Root.localPosition = new Vector3(0f, stand_Height, 0f);

        is_Crouching = false;
    }

    void Crouch()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            look_Root.localPosition = new Vector3(0f, crouch_Height, 0f);
            GetComponent<PlayerMovement>().speed = crouch_Speed;

            is_Crouching = true;

            player_Footsteps.steep_Distance = crouch_Step_Distance;
            player_Footsteps.volume_Min = crouch_Volume;
            player_Footsteps.volume_Max = crouch_Volume;
        }
    }
}
