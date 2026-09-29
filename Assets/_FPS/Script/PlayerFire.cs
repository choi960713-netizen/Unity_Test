using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //1. 총알발사 (레이) / 충돌지점에 파편만 튀기기
    //2. 수류탄 발사 
    
    
    public Transform firePoint;     //총알 발사 위치
    public GameObject hitImpactFactory;     //총알파편 프리팹
    public GameObject bombFactory;          //수류탄 프리팹
    public float power = 10f;       //던질파워


    void Update()
    {
        //마우스 왼쪽버튼 (총알발사)
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            //레이랑 충돌했냐?
            if(Physics.Raycast(ray, out hit))
            {
                print("충돌 오브젝트: " + hit.collider.name);
                //충돌지점에 총알 파편만 생성하면 된다.
                GameObject bulletImpact = Instantiate(hitImpactFactory);
                //착탄지점
                bulletImpact.transform.position = hit.point;
                //파편에 부딪힌 지점이 향하는 방향으로 총알파편이 튀어야 자연스럽다
                //Hit 정보안에 노멀벡터의 값도 알 수 있다.
                //법선벡터, 노멀벡터 => 평면에 수직인 벡터
                bulletImpact.transform.forward = hit.normal;

                //레이어 마스크 사용 충돌처리 (최적화)
                //tag보다 약 20배 빠르다 (비트연산)
                //총 32비트를 사용하기 떄문에 32개까지 추가 가능

                //int layer = gameObject.layer;

                //layer = 1 << 6;  //플레이어
                //0000 0000 0000 0001 => 0000 0000 0010 0000    =>왼쪽으로 6칸 옮김
                //0000 0000 0010 0000 => 플레이어
                //0000 0000 0000 1000 => 에너미
                //0000 0000 1000 0000 => 보스

                //layer = 1 << 8 | 1 << 4 | 1 << 6;
                ////0000 0000 1010 1000
                //if(Physics.Raycast(ray,out hit, 100,layer)) //모두다 충돌처리
                //{
                //}
                //if (Physics.Raycast(ray, out hit, 100, ~layer)) //모두다 제외처리
                //{
                //    //if(player.layer)
                //    //if(enemy.layer)
                //}


            }
        }
        //마우스 오른쪽버튼(수류탄 투척)
        if(Input.GetMouseButtonDown(1))
        {
            //폭탄생성
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePoint.position;

            //폭탄은 플레이어가 던지기 때문에
            //폭탄이 들고 있는 리기드바디를 이용하면 된다
            Rigidbody rb = bomb.GetComponent<Rigidbody>();

            //45도 정도의 각도를 발사
            //벡터의 덧셈 (UP + Forward)
            //각도를 높이고싶디 => Up의 길이를 늘려준다
            //각도를 낮추고 싶다 => Forwardd의 길이를 늘려준다
            //Vector3 dir = Camera.main.transform.up + Camera.main.transform.forward;
            Vector3 dir = Camera.main.transform.up + (Camera.main.transform.forward * 2f);
            dir.Normalize();
            rb.AddForce(dir*power,ForceMode.Impulse);

            //ForceMode.Impulse  => 순간적인 힘을 가한다
            //Forcemode.Vellocity => 순간적안 함을 가한다
            //ForceMode.Force =. 연속적인 힘을 가한다 (질량의 영향을 받는다)
            //ForceMode.Acceleration => 연속적인 힘을 가한다(질량의 영향을 받지않는다.


        }
        //스나이프 모드
        If(Input.GetKey(KeyCode,Ecape)
        {

        }

    }
}
