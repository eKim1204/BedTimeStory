using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_EnemyHp : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] Enemy enemy;


    Slider slider_hp;
    GameObject go;

    Transform t;

    //=====================================================================
    void Start()
    {
        mainCamera = Camera.main;
        go= gameObject;
        t=transform;
    }

    void Update()
    {
        // HP바 위치 업데이트 (화면에서 적 위치에 맞춤)
        // Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position + Vector3.up * 2); // 적의 위에 HP바 표시
        Vector3 currPos = enemy.t.position+ Vector3.up *2;
        
        if (currPos.z > 0 && IsInViewport(currPos))
        {
            go.SetActive(true);


            transform.position = currPos;
        }
        else
        {
            // 카메라 뒤에 있으면 HP바를 숨김
            go.SetActive(false);
        }
    }


    private bool IsInViewport(Vector3 currPos)
    {
        Vector2 screenPos = mainCamera.WorldToScreenPoint(currPos);
        
        return screenPos.x >= 0 && screenPos.x <= Screen.width &&
               screenPos.y >= 0 && screenPos.y <= Screen.height;
    }


    public void Init(Enemy enemy)
    {
        this.enemy = enemy;

        slider_hp = GetComponent<Slider>();
        slider_hp.maxValue = enemy.maxHp;
        slider_hp.value = enemy.currHp;
    }

    public void OnUpdateEnemyHp()
    {
        slider_hp.value = enemy.currHp;
    }


    public void OnEnemyDie()
    {
        Destroy(gameObject);
    }
}
