using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

namespace RubiusImage.Interface.Card
{
    public static class CardStorage
    {
        private static readonly Dictionary<int, CardView> _cardImageStorage = new Dictionary<int, CardView>();

        public static void CardRegistered(int id, CardView view)
        {
            if (view != null && !_cardImageStorage.ContainsKey(id))
            {
                _cardImageStorage.Add(id, view);
            }
        }

        public static CardView GetCardImage(int id)
        {
            if (!_cardImageStorage.ContainsKey(id))
            {
                return null;
            }

            return _cardImageStorage[id];
        }

        public static void ResetAnimation()
        {
            for (int i = 0; i < _cardImageStorage.Count; i++)
            {
                _cardImageStorage[i].OnAnimReset?.Invoke();
            }
        }
    }
}
