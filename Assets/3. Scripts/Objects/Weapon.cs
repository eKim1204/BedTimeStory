using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform muzzle;

    bool isAiming = false;
    float rocketSpeed = 100;

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
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

    void Shoot()
    {
        if (!isAiming)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
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

            GameObject projectile = Instantiate(projectilePrefab,
                muzzle.position, Quaternion.Euler(projectileDir));

            projectile.GetComponent<Rigidbody>().AddForce(projectileDir * rocketSpeed, ForceMode.Impulse);
        }
    }
}
