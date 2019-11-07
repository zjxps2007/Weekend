using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour {

    public GameObject Player;
    public GameObject JoyPad;
    public GameObject Stick;
    public float camera_Speed = 10.0f;
    private Vector2 axis;
    private Touch joyStick_Touch;
    private Touch cameraMoving_Touch;

    private float radius;
    private Vector2 cam_center;
    private Vector2 cam_Move_Val;
    private Vector2 center;
    private Transform cam;

    private void Camera_Move()
    {
        if (cameraMoving_Touch.phase == TouchPhase.Began)
        {
            cam_center = cameraMoving_Touch.position;
        }

        cam_Move_Val = cam_center - cameraMoving_Touch.position;

        cam_center = cameraMoving_Touch.position;
        Player.transform.Rotate(0, -cam_Move_Val.x * camera_Speed * Time.deltaTime, 0);
        
        if (cameraMoving_Touch.phase == TouchPhase.Ended)
        {
            Player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        if (cam.rotation.x >= 0.7f)
        {
            if (cam_Move_Val.y * camera_Speed * Time.deltaTime < 0)
            {
                cam.Rotate(cam_Move_Val.y * camera_Speed * Time.deltaTime, 0, 0);
            }
        }
        else if (cam.rotation.x <= -0.7f)
        {
            if (cam_Move_Val.y * camera_Speed * Time.deltaTime > 0)
            {
                cam.Rotate(cam_Move_Val.y * camera_Speed * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            cam.Rotate(cam_Move_Val.y * camera_Speed * Time.deltaTime, 0, 0);
        }
    }

    private void Stick_Move()
    {
        Vector2 touchPos;
        touchPos = new Vector2(joyStick_Touch.position.x/Screen.width*1920, joyStick_Touch.position.y/Screen.height*1080) + new Vector2(-960, -540);

        if (joyStick_Touch.phase == TouchPhase.Began)
        {
            center = touchPos;
            if (center != new Vector2(-960, -540))
            {
                JoyPad.GetComponent<RectTransform>().localPosition = center;
                Stick.GetComponent<RectTransform>().localPosition = center;
                JoyPad.SetActive(true);//패드 보이기
                Stick.SetActive(true);//스틱 보이기
            }
            else
            {
                joyStick_Touch.phase = TouchPhase.Ended;
            }
        }

        float distance = Vector2.Distance(touchPos, center);

        if (distance > radius)
        {
            axis = (touchPos - center).normalized;
        }
        else
        {
            axis = (touchPos - center)/radius;
        }

        Stick.GetComponent<RectTransform>().localPosition = center + axis * radius;

        if (joyStick_Touch.phase == TouchPhase.Ended)
        {
            JoyPad.SetActive(false);//패드 숨기기
            Stick.SetActive(false);//스틱 숨기기
            axis = Vector2.zero;
            Stick.GetComponent<RectTransform>().localPosition = center;
        }

        Player.GetComponent<Player_Move>().player_move(axis.normalized);
    }

    private void GetTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch tempTouch;
            Touch leftTouch;
            Touch rightTouch;
            bool left_Touched = false;
            bool right_Touched = false;
            for (int i = 0; i < Input.touchCount; i++)
            {
                tempTouch = Input.GetTouch(i);
                if (tempTouch.position.x < Screen.width / 2 && !left_Touched)
                {
                    leftTouch = tempTouch;
                    joyStick_Touch = leftTouch;
                    left_Touched = true;
                }
                else if (tempTouch.position.x >= Screen.width / 2 && !right_Touched)
                {
                    rightTouch = tempTouch;
                    cameraMoving_Touch = rightTouch;
                    right_Touched = true;
                }
                if (left_Touched && right_Touched)
                {
                    break;
                }
            }
        }
    }

    void Start()
    {
        cam = Player.transform.GetChild(0);
        radius = JoyPad.GetComponent<RectTransform>().sizeDelta.y/2;
    }

    void Update () {
        GetTouch();
        if (cameraMoving_Touch.phase == TouchPhase.Began || cameraMoving_Touch.phase == TouchPhase.Moved || cameraMoving_Touch.phase == TouchPhase.Ended)
        {
            Camera_Move();
        }
        if (joyStick_Touch.phase == TouchPhase.Began || joyStick_Touch.phase == TouchPhase.Moved || joyStick_Touch.phase == TouchPhase.Ended)
        {
            Stick_Move();
        }
	}
}
