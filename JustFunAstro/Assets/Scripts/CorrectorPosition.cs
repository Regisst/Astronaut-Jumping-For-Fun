using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectorPosition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.gameObject.transform.position = transform.position;
        }
    }
}
