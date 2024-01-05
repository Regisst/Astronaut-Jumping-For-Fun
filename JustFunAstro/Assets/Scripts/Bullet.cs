using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] bool isLeftTower;

    private Vector3 targetPos;

    private void Start()
    {
        if (isLeftTower)
        {
            targetPos = transform.position + new Vector3(4, 0, 0);
        }
        else
        {
            targetPos = transform.position - new Vector3(4, 0, 0); ;
        }
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if(transform.position == targetPos)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Destroy(this.gameObject);
            player.GetDamage(1);
        }
    }
}
