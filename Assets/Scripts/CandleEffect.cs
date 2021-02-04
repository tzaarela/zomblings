using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;

public class CandleEffect : MonoBehaviour
{
    public List<Transform> flames;
    public float duration = 1f;
    public float endValue = 1.2f;
    public List<Tween> tweens;

    private void Start()
    {
        tweens = new List<Tween>();

        foreach (var flame in flames)
        {
            var tween = flame.DOScale(new Vector3(endValue, endValue, 0), duration).SetEase(Ease.InOutFlash).SetLoops(-1, LoopType.Yoyo);
            tweens.Add(tween);
        }
    }

    private void OnDestroy()
    {
        foreach (var tween in tweens)
        {
            if (tween != null)
            {
            tween.Kill();
            }
        }
    }
}
