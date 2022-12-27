using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    //Transform _target;
    private float dampSpeed = 10;  // 따라가는 속도
    public Transform _target;

    // Update is called once per frame
    void Update () {
        FollowTarget();
    }

    public void TargetFind()
    {
        // 타겟 string을 바꿈
        //_target = GameObject.Find("Player").GetComponent<Transform>();
    }

    void FollowTarget()
    {

        // Target is within range.
        transform.position = Vector2.Lerp(transform.position, _target.position, Time.deltaTime * dampSpeed);

    }
}
