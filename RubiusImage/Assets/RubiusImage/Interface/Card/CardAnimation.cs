using DG.Tweening;
using UnityEngine;

namespace RubiusImage.Interface.Card
{
    public class CardAnimation : MonoBehaviour
    {
        [SerializeField] private CardView cardView;

        private void Start()
        {
            cardView.OnAnimReady += Animation;
            cardView.OnAnimReset += ResetAnimation;
        }

        private void ResetAnimation()
        {
            var sequence = DOTween.Sequence();
             sequence.Append(transform.DOShakePosition(1f, 10f, 20, 10f, true));
             sequence.Join(cardView.cardImage.DOFade(0f, 1f));
             sequence.Append(transform.DOMoveY(-100f, 0f, true));
             sequence.Append(cardView.cardImage.DOFade(1f, 0f));
        }
        
        private void Animation()
        {
            transform.DOMoveY(0f, 1f, true);
        }
    }
}