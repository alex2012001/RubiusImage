using System;
using UnityEngine;
using UnityEngine.UI;

namespace RubiusImage.Interface.Card
{
    public class CardView : MonoBehaviour
    {
        public Action OnAnimReady;
        public Action OnAnimReset;
        
        public Image cardImage;
        
        [SerializeField] private int id;
        
        public void CardAnimReady()
        {
            OnAnimReady?.Invoke();
        }
        
        private void Start()
        {
            CardStorage.CardRegistered(id, this);
        }
    }
}
