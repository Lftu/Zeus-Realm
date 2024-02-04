using UnityEngine;
using DG.Tweening;

namespace Game{
    public static class MenuAnimation
    {
        private const float time = 0.5f, fadeOn = 1, fadeOff = 0;
        public static void Animate(this GameObject obj, bool isActivate)
        {
            obj.SetActive(true);
            CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
            canvasGroup.DOFade(isActivate ? fadeOn : fadeOff, time).OnComplete(() =>
            {
                if (!isActivate)
                {
                    obj.SetActive(false);
                }
            });
        }

    }
}

