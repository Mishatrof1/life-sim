using System;
using DG.Tweening;
using UnityEngine;

namespace Screens
{
    public class ScreenViewBase : MonoBehaviour
    {
        private Action<ScreenViewBase> _onAppearAnimationCompleteAction;
        private Action<ScreenViewBase> _onHideAnimationCompleteAction;
        private float _animationDuration = 0f;

        public virtual bool BlockPopups => false;

        public void DoAppearAnimation(Vector2 direction, Action<ScreenViewBase> onComplete)
        {
            _onAppearAnimationCompleteAction = onComplete;
            var startOffset = CalculateOffset(direction * -1);
            var targetPos = transform.localPosition;
            
            if (Math.Abs(startOffset.sqrMagnitude) - Math.Abs(Vector2.zero.sqrMagnitude) > Mathf.Epsilon)
            {
                transform.localPosition += startOffset;
                transform.DOLocalMove(targetPos, _animationDuration).SetEase(Ease.InOutCubic).OnComplete(OnAppearAnimationComplete);
            }
        }

        public void DoHideAnimation(Vector2 direction, Action<ScreenViewBase> onComplete)
        {
            _onHideAnimationCompleteAction = onComplete;
            var targetPos = CalculateOffset(direction);

            if (Math.Abs(targetPos.sqrMagnitude) - Math.Abs(Vector2.zero.sqrMagnitude) > Mathf.Epsilon)
            {
                transform.DOLocalMove(targetPos, _animationDuration).SetEase(Ease.InOutCubic).OnComplete(OnHideAnimationComplete);
            }
        }
        
        private void OnAppearAnimationComplete()
        {
            _onAppearAnimationCompleteAction?.Invoke(this);
        }
        
        private void OnHideAnimationComplete()
        {
            _onHideAnimationCompleteAction?.Invoke(this);
        }

        private Vector3 CalculateOffset(Vector2 direction)
        {
            if ((direction - Vector2.right).sqrMagnitude < Mathf.Epsilon
                || (direction - Vector2.left).sqrMagnitude < Mathf.Epsilon)
            {
                _animationDuration = 0.3f;
                return direction.normalized *
                       GameProcessingEcs.Instance.MainCanvas.GetComponent<RectTransform>().sizeDelta.x;
            }
            if ((direction - Vector2.up).sqrMagnitude < Mathf.Epsilon
                || (direction - Vector2.down).sqrMagnitude < Mathf.Epsilon)
            {
                _animationDuration = 0.4f;
                return direction.normalized *
                       GameProcessingEcs.Instance.MainCanvas.GetComponent<RectTransform>().sizeDelta.y;
            }

            return Vector3.zero;
        }
    }
}