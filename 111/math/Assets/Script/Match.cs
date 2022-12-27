using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Match : MonoBehaviour
{
    public static int enemyNum = 0;
    public GameObject enemyObject;//적 오브젝트
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyNum <= 0) {//TODO
            stage(10);
        }
    }
    /*
    스테이지 시작할떄 적을 생성하는 함수
    */
    void stage(int num)
    {
        enemyNum = num;
        int random = 0;
        Vector3 position;

        //지정한 수만큼 적 복제
        for(int i = 0; i < num; i++){

            //랜덤으로 적의 위치 지정
            random = Random.Range(0, 4);
            if (random == 0){
                position = new Vector3(Random.Range(-40.0f, 40.0f), 20, 0);
            } else if (random == 1) {
                position = new Vector3(Random.Range(-40.0f, 40.0f), -20, 0);
            } else if (random == 2) {
                position = new Vector3(40, Random.Range(-20.0f, 20.0f), 0);
            } else {
                position = new Vector3(-40, Random.Range(-20.0f, 20.0f), 0);
            }

            //적 복제
            GameObject enemy = Instantiate(enemyObject, position, transform.rotation);
            Rigidbody2D rigid_enemy = enemy.GetComponent<Rigidbody2D>();
        }
    }
}
