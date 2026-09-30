using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //카메라가 플레이어를 따라다니기
    //플레이어한테 바로 카메라를 자식으로 붙여서 이동해도 상관없다
    //하지만 게임에 따라 드라마틱한 연출이 필요한 경우
    //타겟을 따라다니도록 해서 처리를 한다
    //또한 1인칭, 3인칭으로 변경도 자유롭게 할수 있다
    //지금은 우리 눈 역할을 할거라서 그냥 순간이동 시킨다

    //public Transform target;        //카메라가 따라다닐 타겟
    public float speed = 5f;          //카메라 이동속도
    public Transform target1st;       //카메라가 따라다닐 타겟 1인칭 시점
    public Transform target3st;         //카메라가 따라다닐 타겟 3인칭 시점
    bool isFPS = true;

    void Update()
    {
        //1인칭 to 3인칭, 3인칭 to 1인칭으로 카메라변경
        ChangeView();
    }
    void ChangeView()
    {
        if(Input.GetKeyDown("1"))
        {
            isFPS = true;
        }
        if (Input.GetKeyDown("3"))
        {
            isFPS = false;
        }

        if(isFPS)       //1인칭이냐
        {
            //카메라 위치를 강제로 타켓위치로 고정
            transform.position = target1st.position;
        }
        else            //3인칭이냐
        {
            transform.position = target3st.position;

        }
        {

        }

    }

    private void LateUpdate()
    {
        //FollowTarget();
    }
    //void FollowTarget()
    //{
    //    //카메라가 플레이어를 따라다닐때 주의사항
    //    //이때는 업Update()가 아닌 LateUpdate()에 넣어주는게 좋다


    //    //타겟의 방향 구하기 (벡터의 뺄셈)
    //    //방향 = 타겟 - 자기자신
    //    Vector3 dir = target.position - transform.position;
    //    dir.Normalize();
    //    transform.Translate(dir*speed*Time.deltaTime);

    //    if(Vector3.Distance(transform.position,target.position)<1.0f)
    //    {
    //        transform.position = target.position;
    //    }

    //}
    private void Move()
    {
        //1. 플레이어를 향해 이동 후 공격범위안에 들어오면 공격상태 변경
        //2. 플레이어를 추격하더라도 처음위치에서 일정범위를 넘어가면 리턴상태로 변경
        //-플레이어처럼 캐릭터 컨트롤러이용하기
        //-공격범위 1미터
        //- 상태변경
        //-상태 전환출력
    }
    private void Attack()
    {
        //1. 플레이어가 공격범위 안에 있다면 일정한 시간간격으로 플레이어 공격
        //2. 플레이어가 공격범위를 벗어나면 이동상태로 변경
        //3. 공격범위 1미티
        //-상태변경
        //-상태전환 (log)
    }
    private void Return()
    {
        //1.몬스터가 플레이어를 추격하더라도 처음 위치에서 일정범위를 벗어나면 다시 돌아옴
        //- 처음 위치에서 일정범위 30미터
        //- 상태변경
        //-상태출력
    }
    private void Damage()
    {
        //코루틴을 사용하자
        //1. 몬스터 체력이 1이상
        //2. 다시 이전상태로 변경
        //-상태변경
        //-상태전환 출력
    }
    private void Die()
    {
        //코루틴
        //1. 체력이 0이하
        //2. 몬스터 오브젝트 삭제
        //-상태변경
        //-상태변경 출력
    }
}
