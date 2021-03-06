﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool hasTarget = false;
    [SerializeField]private float speed;
    private Rigidbody rigidbody;
    [SerializeField]
    private float damage;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 target)
    {
        hasTarget = true;
        transform.LookAt(target);
        rigidbody.AddForce( (target - transform.position).normalized * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
        Player player = other.gameObject.GetComponent<Player>();
        if (enemy != null)
        {
            enemy.GetDamage(damage);
            Destroy(gameObject);
        }

        if (player != null)
        {
            player.GetDamage(damage);
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
            rigidbody.isKinematic = true;
    }

}
