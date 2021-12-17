using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Turret : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;


    float timer = 2;
    float countdown = 0;

    private Enemy _target;
    private List<Enemy> _queueOfEnemy;

    private void Awake()
    {
        _queueOfEnemy = new List<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _queueOfEnemy.Add(other.GetComponent<Enemy>());
        _target = _queueOfEnemy.FirstOrDefault<Enemy>();
    }

    private void OnTriggerExit(Collider other)
    {
        _queueOfEnemy.Remove(other.GetComponent<Enemy>());
        if (_queueOfEnemy.Count > 0)
        {
            _target = _queueOfEnemy.FirstOrDefault<Enemy>();
        }
        else
        {
            _target = null;
        }
    }

    private void Update()
    {

        if (_target != null)
        {
            _weapon.transform.LookAt(_target.transform, Vector3.up);
        }
        if (countdown <= timer)
        {
            countdown += Time.deltaTime;
        }
        else
        {
            _weapon.Shoot();
            countdown = 0;
        }
        Debug.Log(countdown);
    }
}
