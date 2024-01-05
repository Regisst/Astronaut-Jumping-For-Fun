using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    [SerializeField] Transform fallPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            player.LongTarget = fallPlatform.position;
            player.IsLongJumping = true;
        }
    }
}
