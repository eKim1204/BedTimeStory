using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hitPrefab;
    public List<GameObject> trails;
    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(2);

        Explode();
    }

    protected void Explode()
    {
        if (trails.Count > 0)
        {
            for (int i = 0; i < trails.Count; i++)
            {
                trails[i].transform.parent = null;
                var ps = trails[i].GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Stop();
                    Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
                }
            }
        }
        if (hitPrefab != null)
        {
            var hitVFX = Instantiate(hitPrefab, transform.position, Quaternion.identity) as GameObject;

            var ps = hitVFX.GetComponent<ParticleSystem>();
            if (ps == null)
            {
                var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitVFX, psChild.main.duration);
            }
            else
                Destroy(hitVFX, ps.main.duration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Damage Enemy
        DamageEnemy(other);
        Debug.Log("!");
        Explode();
        StartCoroutine(DestroyParticle(0f));
        
    }

    protected virtual void DamageEnemy(Collider co)
    {
        Enemy enemy = null;
        if (enemy = co.gameObject.GetComponent<Enemy>())
        {
            enemy.GetDamaged(PlayerStats.Instance.AttackPower);
        }
    }

    public IEnumerator DestroyParticle(float waitTime)
    {

        if (transform.childCount > 0 && waitTime != 0)
        {
            List<Transform> tList = new List<Transform>();

            foreach (Transform t in transform.GetChild(0).transform)
            {
                tList.Add(t);
            }

            while (transform.GetChild(0).localScale.x > 0)
            {
                yield return new WaitForSeconds(0.01f);
                transform.GetChild(0).localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                for (int i = 0; i < tList.Count; i++)
                {
                    tList[i].localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                }
            }
        }

        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
