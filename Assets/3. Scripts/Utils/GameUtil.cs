using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameUtil
{
    public static class GameUtil 
    {
        public static float GetSqrDistWith(this Vector3 currPos, Vector3 targetPos)
        {   
            return (targetPos - currPos).sqrMagnitude;
        }

        public static float GetDistWith(this Vector3 currPos, Vector3 targetPos)
        {   
            return Vector3.Distance(currPos, targetPos);
        }
    }
}

