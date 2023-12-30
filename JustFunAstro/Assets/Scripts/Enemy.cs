using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform _startPos;

    private GameObject _bulletFire;

  
    private void Fire()
    {
        _bulletFire = Instantiate(bulletPref, _startPos.position, Quaternion.identity) as GameObject;
    }


    private void Update()
    {
        if (_bulletFire == null)
        {
            Fire();
        }
    }

}
