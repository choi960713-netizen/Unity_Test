using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravity = -20f;       
    float velocityY;                    //낙하속도
    public float jump = 10f;            //점프파워
    int jumpCount = 0;                  //2단점프

    CharacterController cc;
    // Update is called once per frame
    void Start()
    {
        cc=GetComponent<CharacterController>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v =Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0f, v);
        dir = Camera.main.transform.TransformDirection(dir);

        //착지자리(점프중 리셋되지 않도록)
        if(cc.isGrounded && velocityY <0)
        {
            velocityY = -2f;    //바닥에 살짝 눌러붙게 해서 접지판정을 원활히 하기위해
            jumpCount = 0;
        }

        //점프 및 2단점프
        if(Input.GetButtonDown("Jump")&& jumpCount <2)
        {
            jumpCount++;
            velocityY = jump;
        }

        //중력 적용 (그냥 항상)
        velocityY += gravity * Time.deltaTime;

        //수평은 스피드적용, 수직은 스피드 적용 안함
        Vector3 velocity = dir * speed;
        velocity.y = velocityY;

        cc.Move(velocity * Time.deltaTime);
    }

    //점프 문제있는 함수
    void PrevMove()
    {
        //이동처리 방법
        //1. transform.position
        //2. transform.Translate()
        //3. RigidBody.velocity
        //4. CharacterController.Move()

        //플레이어 이동
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0f, v);

        //dir.Normalize();
        //transform.Translate(dir * speed * Time.deltaTime);
        //바라보는 방향에 따라 다르다
        //카메라가 바라보는 방향으로 이동하는게 자연스럽다.
        dir =Camera.main.transform.TransformDirection(dir);
        //transform.Translate(dir * speed * Time.deltaTime);

        //문제점 : 하늘을 날라다닌다, 땅을 뚫는다, 충돌안됨!!
        //캐릭터 컨트롤러 컴포넌트를 사용한다!!
        //캐릭터 컨트롤러는 충돌감지만하고 물리적용안됨
        //따라서 리기드바디보다 훨씬 가볍다.
        //실제움직임 보다는 과장된 움직임을 표현하기 좋다
        //cc.Move(dir * speed * Time.deltaTime);

        //transform.position += dir * speed * Time.deltaTime;
        //중력적용하기
        //velocityY += gravity * Time.deltaTime;
        //dir.y = velocityY;

        //캐릭터 점프
        //점프버튼 누르면 수직속도에 점프파워를 넣는다
        //땅에 닿아있는 경우 점프가능하고 VelocityY는 0으로 초기화 해줘야한다.



        //CollisionFlags.Above  => 상단
        //CollisionFlags.Below  => 중단
        //CollisionFlags.Sides  => 하단
        //if(cc.collisionFlags ==CollisionFlags.Below)    //땅에 닿았냐?
        //{

        //}
        //if(cc.isGrounded)
        //{
        //    velocityY = 0;
        //}
        //if (Input.GetButtonDown("Jump"))
        //{
        //    velocityY = jump;
        //}

        //2단점프만 가능하도록 만들기
        //if(cc.isGrounded)
        //{
        //    velocityY = 0;
        //    jumpCount = 0;
        //}
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            velocityY = 0;
            jumpCount = 0;

        }
        else
        {
            //점프 중인 상태라서 중력적용
            velocityY += gravity * Time.deltaTime;
            dir.y = velocityY;
        }

        if(Input.GetButtonDown("Jump")&&jumpCount < 2 )
        {
            jumpCount++;
            velocityY = jump;
        }

        cc.Move(dir * speed * Time.deltaTime);


    }
}
