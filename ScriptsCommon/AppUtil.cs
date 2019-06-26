using System;
using System.Collections;
using UnityEngine;

public class AppUtil
{
    public static IEnumerator DelayMethod(float delayTime, Action action){
        yield return new WaitForSeconds(delayTime);
        action();
    }

    public static IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
    }
}
