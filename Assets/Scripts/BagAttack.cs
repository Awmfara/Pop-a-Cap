using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script Affects Bag Prefabs, n.b. Bag is also affected by Gravity
public class BagAttack : MonoBehaviour
{
    [Header("Bag Speed and Expire Time")]
    [SerializeField, Tooltip("Speed Bag Moves At")]
    private float speed = 10f;
    [SerializeField,Tooltip("Time till item is Destroyed")]
    private float expireTime = 10f;
    private float endTime = 0;

    private void Start()
    {
        endTime = 0;
    }
    /// <summary>
    /// Moves Bag Towards Position, Destroys Object after a period of time
    /// </summary>
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
