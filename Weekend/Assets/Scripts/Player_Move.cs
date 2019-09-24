using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : Move
{
    private Transform cam;

    public override void Start()
    {
        base.Start();
        cam = transform.GetChild(0);
    }

    void Update()
    {
        player_move();
        player_jump();
        player_cam_move();
    }

    private void player_move()
    {
        move(player_get_direction());
    }

    private void player_jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump(player_get_direction());
        }
    }

    private void player_cam_move()
    {
        transform.Rotate(0, Input.GetAxisRaw("Mouse X"), 0);
        if (cam.rotation.x >= 0.7f)
        {
            if (-Input.GetAxisRaw("Mouse Y") < 0)
            {
                cam.Rotate(-Input.GetAxisRaw("Mouse Y"), 0, 0);
            }
        }
        else if (cam.rotation.x <= -0.7f)
        {
            if (-Input.GetAxisRaw("Mouse Y") > 0)
            {
                cam.Rotate(-Input.GetAxisRaw("Mouse Y"), 0, 0);
            }
        }
        else
        {
            cam.Rotate(-Input.GetAxisRaw("Mouse Y"), 0, 0);
        }
    }

    private Vector3 player_get_direction()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) direction.z += 1;
        if (Input.GetKey(KeyCode.A)) direction.x += -1;
        if (Input.GetKey(KeyCode.S)) direction.z += -1;
        if (Input.GetKey(KeyCode.D)) direction.x += 1;
        return direction.normalized;
    }
}
