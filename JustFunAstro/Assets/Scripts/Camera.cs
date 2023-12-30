using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Transform blackHolePos;
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        if(playerPos != null)
        {
            if(playerPos.position.y < blackHolePos.position.y + 3)
            {
                Vector3 newPos2 = new Vector3(transform.position.x, blackHolePos.position.y + 5, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, newPos2, speed * Time.deltaTime);
            }
            else
            {
                Vector3 newPos1 = new Vector3(transform.position.x, playerPos.position.y + 2, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, newPos1, speed * Time.deltaTime);
            }
        }
    }
}
