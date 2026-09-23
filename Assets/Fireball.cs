using UnityEngine;

public class Fireball : MonoBehaviour
{
    float speed = 10f;  //이동속도
    float maxDistance = 10f;    //최대 사거리
    Rigidbody rb;
    Vector3 startPosition;      //발사 시작위치 (거리로 판별하기 위한 시작위치)

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.linearVelocity =transform.forward*speed;
        startPosition = transform.position;
    }

    void Update()
    {
     rb.linearVelocity -=transform.forward*speed;

        //사거리 도달시 파이어볼 삭제
        if(Vector3.Distance(startPosition,transform.position)>=maxDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
