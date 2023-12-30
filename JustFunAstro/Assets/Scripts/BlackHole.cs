using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] int damage = 999;
    [SerializeField] float speed = 0.25f;
    [SerializeField] Transform playerPos;

    private void Update()
    {
        if (playerPos != null)
        {
            Vector3 newPos = new Vector3(transform.position.x, playerPos.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("hit");
            player.GetDamage(damage);
        }
    }
}
