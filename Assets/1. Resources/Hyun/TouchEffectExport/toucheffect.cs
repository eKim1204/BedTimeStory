using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffect3D : MonoBehaviour
{
    private ParticleSystem particleSystem;

    public float lifeTime = 1f;
    public float initialScale = 0.5f; // 초기 스케일 크기 (원하는 크기로 조정)

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        // 이펙트의 초기 스케일 설정
        transform.localScale = new Vector3(initialScale, initialScale, initialScale);

        Destroy(gameObject, lifeTime);
    }
}
