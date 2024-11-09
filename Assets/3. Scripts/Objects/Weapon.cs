using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject rocketProjectilePrefab;
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject reloadParticleSystem;

    bool isAiming = false;
    float projectileSpeed = 100f;
    float rocketProjectileSpeed = 50f;

    float currSkillCooltime = 0f;

    const int maxAmmo = 10;
    int currAmmo = maxAmmo;

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
        Reload();
    }

    private void Aim()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isAiming = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isAiming = false;
        }
    }

    private void Shoot()
    {
        if (!isAiming)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (currAmmo == 0)
            {
                Reload();
                return;
            }
            else
            {
                currAmmo--;
            }

            Vector3 projectileDir = CalcDir();

            GameObject projectile = Instantiate(projectilePrefab,
                muzzle.position, Quaternion.Euler(projectileDir));

            projectile.GetComponent<Rigidbody>().AddForce(projectileDir * projectileSpeed, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 projectileDir = CalcDir();

            GameObject projectile = Instantiate(rocketProjectilePrefab,
                muzzle.position, Quaternion.Euler(projectileDir));

            projectile.GetComponent<Rigidbody>().AddForce(projectileDir * rocketProjectileSpeed, ForceMode.Impulse);
        }
    }

    private void Reload()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(currAmmo < maxAmmo)
            {
                StartCoroutine(ReloadCoroutine());
            }
        }
    }

    private IEnumerator ReloadCoroutine()
    {
        ParticleSystem[] pss = reloadParticleSystem.GetComponentsInChildren<ParticleSystem>();

        float desiredDuration = PlayerStats.Instance.ReloadSpeed;

        foreach (var ps in pss)
        {
            Debug.Log("파티클 이펙트 재생");
            float originalDuration = ps.main.duration;

            var psMain = ps.main;

            Debug.Log("originalDuration : " + originalDuration);
            Debug.Log("파티클 이펙트 재생");


            psMain.simulationSpeed = originalDuration/desiredDuration; 
            ps.Play();
        }

        yield return new WaitForSeconds(PlayerStats.Instance.ReloadSpeed);

        currAmmo = maxAmmo;
    }

    private Vector3 CalcDir()
    {
        Vector3 startPos = muzzle.position;
        Vector3 endPos;

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 10000))
        {
            endPos = hitInfo.point;
        }
        else
        {
            endPos = Camera.main.transform.position + Camera.main.transform.forward * 10000;
        }

        Vector3 projectileDir = Vector3.Normalize((endPos - startPos));
        return projectileDir;
    }
}
