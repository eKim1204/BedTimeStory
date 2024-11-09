using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Update is called once per frame
    void Update()
    {
        var status = PlayerStats.Instance.playerStatus;
        switch(status)
        {
            case PlayerStats.Status.Idle:
                animator.SetBool("isRunning", false);
                break;  
            case PlayerStats.Status.Walk:
                animator.SetBool("isRunning", true);
                break;
            case PlayerStats.Status.Run:
                animator.SetBool("isRunning", true);
                break;
            default:
                //나머지는 나중에
                break;
        }
    }
}
