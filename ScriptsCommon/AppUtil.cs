using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class AppUtil
{
    public static IEnumerator DelayMethod(float delayTime, Action action){
        yield return new WaitForSeconds(delayTime);
        action();
    }

    public static IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
    }

    public static void SetMaterialFloat(Material mat, string property, float startValue, float endValue, float duration, Ease ease)
    {
        DOTween.To(
            ()=> startValue,
            x =>
            {
                startValue = x;
                mat.SetFloat(property, startValue);
            },
            endValue,
            duration
        ).SetEase(ease);
    }
}

