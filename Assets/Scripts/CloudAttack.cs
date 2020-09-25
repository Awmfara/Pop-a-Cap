using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAttack : MonoBehaviour
{
    [Header("Cloud Speed and Expire Time")]
    [SerializeField, Tooltip("Speed Cloud Moves At")]
    private float speed = 10f;
    [SerializeField, Tooltip("Time till item is Destroyed")]
    private float expireTime = 10f;
    private float endTime = 0;

    /// <summary>
    /// Moves Bag Towards Position, Destroys Object after a period of time
    /// </summary>

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5, 0), speed * Time.deltaTime);

        if (expireTime <= endTime)
        {
            Destroy(gameObject);
        }
        expireTime -= Time.deltaTime;
    }
}
