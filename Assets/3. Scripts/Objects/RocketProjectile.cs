using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : Projectile
{
    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(2);

        Explode();
    }

    private void OnCollisionEnter(Collision co)
    {
        // Damage Enemy
        DamageEnemy(co);

        Explode();
        StartCoroutine(DestroyParticle(0f));
    }

    protected override void DamageEnemy(Collision co)
    {
        var colliders = Physics.OverlapSphere(transform.position, 2f);

        foreach (var collider in colliders)
        {
            Enemy enemy = null;
            if (enemy = collider.gameObject.GetComponent<Enemy>())
            {
                enemy.GetDamaged(PlayerStats.Instance.AttackPower * 2);
            }
        }
    }
}
