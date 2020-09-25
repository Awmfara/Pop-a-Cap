using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smackAttack : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    public float expireTime = 1f;
    public float endTime = 0;


    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(1, 1), speed * Time.deltaTime);

        if (expireTime <= endTime)
        {
            Destroy(gameObject);
        }
        expireTime -= Time.deltaTime;
    }
}
