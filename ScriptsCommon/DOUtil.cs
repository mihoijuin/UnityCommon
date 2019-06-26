using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class DOUtil
{

    public static Sequence DOSequence(Tween[] tweenArray, float prependInterval=0f, float appendInterval=0f, int loopTime=0, TweenCallback action=null){
        Sequence sequence = DOTween.Sequence();
        sequence.PrependInterval(prependInterval);
        sequence.AppendInterval(appendInterval);
        foreach(Tween tween in tweenArray){
            sequence.Append(tween);
        }
        sequence.SetLoops(loopTime);
        sequence.AppendCallback(action);
        return sequence;
    }

    public static IEnumerator WaitDO(Tween tween){
        yield return tween.WaitForCompletion();
    }

    public static IEnumerator WaitDO(Sequence sequence){
        yield return sequence.WaitForCompletion();
    }

    public static void KillDO(Tween tween){
        tween.Kill();
    }

    public static void KillDO(Sequence sequence){
        sequence.Kill();
    }

    public static void PauseDO(Sequence sequence){
        sequence.Pause();
    }

    public static void RestartDO(Sequence sequence){
        sequence.Restart();
    }


    public enum CallbackType { NONE, OnComplete, OnKill, OnPlay, OnPause, OnRewind, OnStart, OnStepComplete, OnUpdate}
    public static void SetCallback(Tween tween, TweenCallback action, CallbackType type){
        switch(type){
            case CallbackType.OnComplete: tween.OnComplete(action); break;
            case CallbackType.OnKill: tween.OnKill(action); break;
            case CallbackType.OnPlay: tween.OnPlay(action); break;
            case CallbackType.OnPause: tween.OnPause(action); break;
            case CallbackType.OnRewind: tween.OnRewind(action); break;
            case CallbackType.OnStart: tween.OnStart(action); break;
            case CallbackType.OnStepComplete: tween.OnStepComplete(action); break;
            case CallbackType.OnUpdate: tween.OnUpdate(action); break;
        }
    }

    public static Tween DOTO(DG.Tweening.Core.DOGetter<Vector3> getter, DG.Tweening.Core.DOSetter<Vector3> setter, Vector3 endValue, float duration, string ease="OutQuad", float delay=0f, int loopTime=0){
        Ease easeType = (Ease)Enum.Parse(typeof(Ease), ease);
        Tween tween = DOTween.To(getter, setter, endValue, duration).SetEase(easeType).SetDelay(delay).SetLoops(loopTime);
        return tween;
    }

    public static Tween DOTO(DG.Tweening.Core.DOGetter<float> getter, DG.Tweening.Core.DOSetter<float> setter, float endValue, float duration, string ease="OutQuad", float delay=0f, int loopTime=0){
        Ease easeType = (Ease)Enum.Parse(typeof(Ease), ease);
        Tween tween = DOTween.To(getter, setter, endValue, duration).SetEase(easeType).SetDelay(delay).SetLoops(loopTime);
        return tween;
    }

    public static Tween Rotate(RectTransform target, Vector3 endValue, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOLocalRotate(endValue, duration).SetEase(ease).SetDelay(delay);
        return tween;
    }

    public static Tween Rotate(Transform target, Vector3 endValue, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOLocalRotate(endValue, duration).SetEase(ease).SetDelay(delay);
        return tween;
    }

    public static Tween Scale(RectTransform target, Vector3 endValue, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOScale(endValue, duration).SetEase(ease).SetDelay(delay);
        return tween;
    }

    public static Tween Scale(Transform target, Vector3 endValue, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOScale(endValue, duration).SetEase(ease).SetDelay(delay);
        return tween;
    }

    public static Tween Show(RectTransform rect, float startValue, float duration, string easeType="OutQuad", float delay=0f, bool stopMode=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        if(stopMode) rect.gameObject.SetActive(true);
        Vector2 targetSize = rect.localScale;
        rect.localScale = new Vector2(targetSize.x * startValue, targetSize.y * startValue);
        Tween tween = rect.DOScale(targetSize, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>rect.gameObject.SetActive(true), CallbackType.OnStart);
        return tween;
    }

    public static Tween ShowX(RectTransform target, float startValue, float duration, string easeType="OutQuad", float delay=0f, bool stopMode=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        if(stopMode) target.gameObject.SetActive(true);
        Vector2 targetSize = target.localScale;
        target.localScale = new Vector2(targetSize.x * startValue, targetSize.y);
        Tween tween = target.DOScaleX(targetSize.x, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(true), CallbackType.OnStart);
        return tween;
    }

    public static Tween ShowX(Transform target, float startValue, float duration, string easeType="OutQuad", float delay=0f, bool stopMode=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        if(stopMode) target.gameObject.SetActive(true);
        Vector2 targetSize = target.localScale;
        target.localScale = new Vector2(targetSize.x * startValue, targetSize.y);
        Tween tween = target.DOScaleX(targetSize.x, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(true), CallbackType.OnStart);
        return tween;
    }

    public static Tween ShowY(RectTransform rect, float startValue, float duration, string easeType="OutQuad", float delay=0f, bool stopMode=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        if(stopMode) rect.gameObject.SetActive(true);
        Vector2 targetSize = rect.localScale;
        rect.localScale = new Vector2(targetSize.x, targetSize.y * startValue);
        Tween tween = rect.DOScaleY(targetSize.y, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>rect.gameObject.SetActive(true), CallbackType.OnStart);
        return tween;
    }

    public static Tween HideX(RectTransform target, float endValue, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType);
        Tween tween = target.DOScaleX(endValue, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(false), CallbackType.OnComplete);
        return tween;
    }

    public static Tween HideX(Transform target, float endValue, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType);
        Tween tween = target.DOScaleX(endValue, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(false), CallbackType.OnComplete);
        return tween;
    }

    public static Tween HideY(RectTransform rect, float endValue, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType);
        Tween tween = rect.DOScaleY(endValue, duration).SetEase(ease).SetDelay(delay);  // 横幅が縮んでいく
        SetCallback(tween, ()=>rect.gameObject.SetActive(false), CallbackType.OnComplete);
        return tween;
    }

    public static Tween Move(RectTransform target, float duration, Vector2 from, Vector2 to, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType);
        target.gameObject.SetActive(true);
        target.anchoredPosition = from;
        Tween tween = target.DOAnchorPos(to, duration).SetEase(ease).SetDelay(delay);
        return tween;
    }

    public static Tween MoveTo(RectTransform target, float duration, Vector3 to, string easeType="OutQuad", float delay=0f, bool resetMode=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType);
        target.gameObject.SetActive(true);
        Vector2 originPos = target.anchoredPosition;
        Tween tween = target.DOAnchorPos(to, duration).SetEase(ease).SetDelay(delay);
        if(resetMode) SetCallback(tween, ()=> target.anchoredPosition = originPos, CallbackType.OnComplete);
        return tween;
    }

    public static Tween MoveTo(Transform target, float duration, Vector3 to, string easeType="OutQuad", float delay=0f, bool resetMode=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType);
        target.gameObject.SetActive(true);
        Vector2 originPos = target.position;
        Tween tween = target.DOMove(to, duration).SetEase(ease).SetDelay(delay);
        if(resetMode) SetCallback(tween, ()=> target.position = originPos, CallbackType.OnComplete);
        return tween;
    }

    public static Tween MoveFrom(RectTransform target, float duration, Vector2 from, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType);
        target.gameObject.SetActive(true);
        Vector2 to = target.anchoredPosition;
        target.anchoredPosition = from;
        Tween tween = target.DOAnchorPos(to, duration).SetEase(ease).SetDelay(delay);
        return tween;
    }

    public static Sequence UpDown(RectTransform target, int moveTime, float downLevel, float upLevel, float downDuration, float upDuration, string downEaseType="OutQuad", string upEaseType="OutQuad", float prependInteval=0f, float appendInteval=0f){
        Tween[] tweenArray = new Tween[moveTime*2];
        Vector2 originPos = target.anchoredPosition;
        for(int i=0; i<moveTime*2;  i+=2){
            tweenArray[i] = DOUtil.MoveTo(target, downDuration, originPos + new Vector2(0, downLevel), downEaseType); // down
            tweenArray[i+1] = DOUtil.MoveTo(target, upDuration, originPos + new Vector2(0, upLevel), upEaseType); // up
        }
        Sequence sequence = DOUtil.DOSequence(
            tweenArray,
            prependInteval,
            appendInteval
        );
        return sequence;
    }

    public static Sequence UpDown(Transform target, int moveTime, float downLevel, float upLevel, float downDuration, float upDuration, string downEaseType="OutQuad", string upEaseType="OutQuad", float prependInteval=0f, float appendInteval=0f){
        Tween[] tweenArray = new Tween[moveTime*2];
        Vector2 originPos = target.position;
        for(int i=0; i<moveTime*2;  i+=2){
            tweenArray[i] = DOUtil.MoveTo(target, upDuration, originPos + new Vector2(0, upLevel), upEaseType); // up
            tweenArray[i+1] = DOUtil.MoveTo(target, downDuration, originPos + new Vector2(0, downLevel), downEaseType); // down
        }
        Sequence sequence = DOUtil.DOSequence(
            tweenArray,
            prependInteval,
            appendInteval
        );
        return sequence;
    }

    public static Sequence Sway(Transform target, int moveTime, float rightLevel, float leftLevel, float rightDuration, float leftDuration, string rightEaseType="OutQuad", string leftEaseType="OutQuad", float prependInteval=0f, float appendInteval=0f, int loopTime=1){
        Tween[] tweenArray = new Tween[moveTime*2];
        Vector3 origin = target.localRotation.eulerAngles;
        for(int i=0; i<moveTime*2;  i+=2){
            tweenArray[i] = Rotate(target, origin + new Vector3(0,0,rightLevel), rightDuration, rightEaseType);
            tweenArray[i+1] = Rotate(target, origin + new Vector3(0,0,leftLevel), leftDuration, leftEaseType);
        }
        Sequence sequence = DOUtil.DOSequence(
            tweenArray,
            prependInteval,
            appendInteval,
            loopTime
        );
        return sequence;
    }

    public static Tween Shake(RectTransform rect, float duration, Vector3 strength, int vibrato, int randomness, string easeType="OutQuad", float delay=0f, int loopTime=0){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType);
        Tween tween = rect.DOShakeAnchorPos(duration, strength, vibrato, randomness, false, false).SetEase(ease).SetDelay(delay).SetLoops(loopTime);
        return tween;
    }

    public static Tween Punch(RectTransform rect, float duration, Vector2 punch, int vibrato=10, float elasticity=1, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType);
        Tween tween = rect.DOPunchScale(punch, duration, vibrato, elasticity).SetEase(ease).SetDelay(delay);
        return tween;
    }

    public static Tween Punch(Transform rect, float duration, Vector2 punch, int vibrato=10, float elasticity=1, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType);
        Tween tween = rect.DOPunchScale(punch, duration, vibrato, elasticity).SetEase(ease).SetDelay(delay);
        return tween;
    }

    public static Tween Scroll(ScrollRect scroll, float targetPos, float duration, string easeType, bool isVertical=true, float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween;
        if(isVertical){
            tween = scroll.DOVerticalNormalizedPos(targetPos, duration, false).SetEase(ease).SetDelay(delay);
        } else {
            tween = scroll.DOHorizontalNormalizedPos(targetPos, duration, false).SetEase(ease).SetDelay(delay);
        }
        return tween;
    }

    public static Tween FadeIn(Image target, float alpha, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFade(alpha, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(true), CallbackType.OnStart);
        return tween;
    }

    public static Tween FadeOut(Image target, float alpha, float duration, string easeType="OutQuad", float delay=0f, bool objectActive=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFade(alpha, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(objectActive), CallbackType.OnComplete);
        return tween;
    }

    public static Tween FadeIn(Text target, float alpha, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFade(alpha, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(true), CallbackType.OnStart);
        return tween;
    }

    public static Tween FadeOut(Text target, float alpha, float duration, string easeType="OutQuad", float delay=0f, bool objectActive=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFade(alpha, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(objectActive), CallbackType.OnComplete);
        return tween;
    }

    public static Tween FadeIn(CanvasGroup target, float alpha, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFade(alpha, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(true), CallbackType.OnStart);
        return tween;
    }

    public static Tween FadeOut(CanvasGroup target, float alpha, float duration, string easeType="OutQuad", float delay=0f, bool objectActive=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFade(alpha, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(objectActive), CallbackType.OnComplete);
        return tween;
    }

    public static Tween FadeIn(SpriteRenderer target, float alpha, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFade(alpha, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(true), CallbackType.OnStart);
        return tween;
    }

    public static Tween FadeOut(SpriteRenderer target, float alpha, float duration, string easeType="OutQuad", float delay=0f, bool objectActive=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFade(alpha, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(objectActive), CallbackType.OnComplete);
        return tween;
    }

    public static Tween FadeIn(TextMeshPro target, float alpha, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFade(alpha, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(true), CallbackType.OnStart);
        return tween;
    }

    public static Tween FadeOut(TextMeshPro target, float alpha, float duration, string easeType="OutQuad", float delay=0f, bool objectActive=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFade(alpha, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(objectActive), CallbackType.OnComplete);
        return tween;
    }

    public static Tween FillIn(Image target, float endValue, float duration, string easeType="OutQuad", float delay=0f){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFillAmount(endValue, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(true), CallbackType.OnStart);
        return tween;
    }

    public static Tween FillOut(Image target, float endValue, float duration, string easeType="OutQuad", float delay=0f, bool objectActive=false){
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOFillAmount(endValue, duration).SetEase(ease).SetDelay(delay);
        SetCallback(tween, ()=>target.gameObject.SetActive(objectActive), CallbackType.OnComplete);
        return tween;
    }

    public static Tween Color(Image target, Color endColor, float duration, string easeType="OutQuad", float delay=0f) {
        Ease ease = (Ease)Enum.Parse(typeof(Ease), easeType, true);
        Tween tween = target.DOColor(endColor, duration).SetEase(ease).SetDelay(delay);
        return tween;
    }

    public static Sequence Blink(Image target, int blinkTime, float darkAlpha, float blightAlpha, float darkDuration, float blightDuration, string darkEaseType="OutQuad", string blightEaseType="OutQuad", float prependInteval=0f, float appendInteval=0f){
        Tween[] tweenArray = new Tween[blinkTime*2];
        for(int i=0; i<blinkTime*2;  i+=2){
            tweenArray[i] = DOUtil.FadeOut(target, darkAlpha, darkDuration, darkEaseType); // dark
            tweenArray[i+1] = DOUtil.FadeIn(target, blightAlpha, blightDuration, blightEaseType); // blight
        }
        Sequence sequence = DOUtil.DOSequence(
            tweenArray,
            prependInteval,
            appendInteval
        );
        return sequence;
    }

    public static Sequence Blink(Text target, int blinkTime, float darkAlpha, float blightAlpha, float darkDuration, float blightDuration, string darkEaseType="OutQuad", string blightEaseType="OutQuad", float prependInteval=0f, float appendInteval=0f){
        Tween[] tweenArray = new Tween[blinkTime*2];
        for(int i=0; i<blinkTime*2;  i+=2){
            tweenArray[i] = DOUtil.FadeOut(target, darkAlpha, darkDuration, darkEaseType); // dark
            tweenArray[i+1] = DOUtil.FadeIn(target, blightAlpha, blightDuration, blightEaseType); // blight
        }
        Sequence sequence = DOUtil.DOSequence(
            tweenArray,
            prependInteval,
            appendInteval
        );
        return sequence;
    }

    public static Sequence Blink(SpriteRenderer target, int blinkTime, float darkAlpha, float blightAlpha, float darkDuration, float blightDuration, string darkEaseType="OutQuad", string blightEaseType="OutQuad", float prependInteval=0f, float appendInteval=0f){
        Tween[] tweenArray = new Tween[blinkTime*2];
        for(int i=0; i<blinkTime*2;  i+=2){
            tweenArray[i] = DOUtil.FadeOut(target, darkAlpha, darkDuration, darkEaseType); // dark
            tweenArray[i+1] = DOUtil.FadeIn(target, blightAlpha, blightDuration, blightEaseType); // blight
        }
        Sequence sequence = DOUtil.DOSequence(
            tweenArray,
            prependInteval,
            appendInteval
        );
        return sequence;
    }

}