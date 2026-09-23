using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseChaser : MonoBehaviour
{
    Vector3 mousePos;      //마우스 좌표
    Vector3 movePos;        //아동할 좌표
    [Range(0.01f, 0.1f)]
    public float time = 0.01f;
    [SerializeField] float distanceZ = 5f;
    void Update()
    {
        //마우스좌표 가져오기
        mousePos = Mouse.current.position.ReadValue();
        //카메라 위치로부터의 거리
        mousePos.z = distanceZ;

        //오브젝트가 마우스 좌표를 따라다니려면
        //마우스 좌표(스크린 좌표) 대한 3D공간좌표를 알아야한다.
        mousePos=Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector3.Lerp(transform.position, mousePos, time);
    }
}
