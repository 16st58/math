using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //https://hangjastar.tistory.com/21

public class player : MonoBehaviour
{
    public int moveSpeed;
    public float maxSpeed;
    public float turnSpeed;
    public float curShotDelay;//발사간 속도
    public float maxShotDelay;//발사 최대속도
    float angle; //플레이어 각도
    public static float health = 10.0f;

    public GameObject gameplayer;//플래이어 오브젝트
    public GameObject bulletObject;//무기 오브젝트
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameplayer.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            Debug.Log("죽음");
        }
        if(Input.GetMouseButton(1)) {
            OnRotationAndMove();
        } else if(Input.GetMouseButton(0)){
            Fire();
        }
        Reload();
        overLine();
    }

    /*
    플레이어가 화면밖을 나갔는지 검사하는 함수
    나가면 반대편으로 이동
    */
    void overLine(){
        if (transform.position.x < -35){
            transform.position = new Vector3(35, transform.position.y, 0);
        }
        else if (transform.position.x > 35){
            transform.position = new Vector3(-35, transform.position.y, 0);
        }
        if (transform.position.y < -18){
            transform.position = new Vector3(transform.position.x, 18, 0);
        }
        else if (transform.position.y > 18){
            transform.position = new Vector3(transform.position.x, -18, 0);
        }
    }

    void Reload(){
        curShotDelay += Time.deltaTime;
    }

    void Fire() {
        if(curShotDelay<maxShotDelay)//장전시간이 충족이안되면
        {
            return;
        }
        //GameObject bullet = Instantiate(bulletObject, transform.position, transform.rotation);

        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 playerPos = transform.position;
        
        Vector2 dirVec = mousePos - (Vector2)playerPos; //그냥 벡터를 만듦
        dirVec = dirVec.normalized; //normalized를 해줘야 방향벡터
        GameObject bullet = Instantiate(bulletObject, transform.position, transform.rotation);
        Rigidbody2D rigid_bullet = bullet.GetComponent<Rigidbody2D>();
        bullet.transform.up = dirVec;
        //총알의 오른쪽 방향을 dirVec(방향벡터)로 설정

        bullet.transform.position = (Vector2)playerPos + dirVec * 0.5f;
        //총알이 플레이어보다 살짝 앞에서 발사(자연스러움)

        rigid.AddForce(-dirVec * Time.deltaTime * moveSpeed); //플레이어가 반대 방향으로 이동
        //dirVec의 정반대의 벡터를 만들기 위해서 (-)를 곱해주면 된다
        curShotDelay = 0;//꼭 초기화해줘야된다.
    }

    //캐릭터 이동
    void OnRotationAndMove() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 target = new Vector2(mousePos.x - transform.position.x,
                                     mousePos.y - transform.position.y);

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward * turnSpeed);

        rigid.AddForce(target * moveSpeed * Time.deltaTime, ForceMode2D.Force);

        if (rigid.velocity.x >= maxSpeed) {rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);}
        else if (rigid.velocity.x <= -1 * maxSpeed) {rigid.velocity = new Vector2( -1 * maxSpeed, rigid.velocity.y);}
        if (rigid.velocity.y >= maxSpeed) {rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed);}
        else if (rigid.velocity.y <= -1 * maxSpeed) {rigid.velocity = new Vector2(rigid.velocity.x,-1 * maxSpeed);}
    }
}
