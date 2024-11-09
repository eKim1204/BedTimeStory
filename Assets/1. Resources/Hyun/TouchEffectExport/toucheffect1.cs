using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffectManager3D : MonoBehaviour
{
    public GameObject touchEffectPrefab; // 3D 터치 이펙트 프리팹
    public float defaultTime = 0.05f; // 이펙트 생성 간격
    private float touchTime;

    void Update()
    {
        // 터치 또는 마우스 클릭 시 이펙트 생성
        if ((Input.touchCount > 0 || Input.GetMouseButton(0)) && touchTime >= defaultTime)
        {
            CreateTouchEffect();
            touchTime = 0;
        }

        touchTime += Time.deltaTime;
    }

    void CreateTouchEffect()
    {
        Vector3 point;

        if (Input.touchCount > 0) // 터치 입력
        {
            Touch touch = Input.GetTouch(0);
            point = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
        }
        else // 마우스 입력
        {
            point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        }

        // 터치 이펙트 생성
        GameObject effect = Instantiate(touchEffectPrefab, point, Quaternion.identity);
    }
}
