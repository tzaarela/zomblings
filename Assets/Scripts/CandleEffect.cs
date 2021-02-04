using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CandleEffect : MonoBehaviour
{
    public List<Transform> flames;

    public float duration = 1f;
    public float endValue = 1.2f;

    private void Start()
    {
        foreach (var flame in flames)
        {
            flame.DOScale(new Vector3(endValue, endValue, 0), duration).SetEase(Ease.InOutFlash).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
