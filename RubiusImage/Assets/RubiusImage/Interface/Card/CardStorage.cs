using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

namespace RubiusImage.Interface.Card
{
    public class CardStorage : MonoBehaviour
    {
        private static Dictionary<int, Image> _cardImageStorage = new Dictionary<int, Image>();

        public static void CardRegistered(int id, Image view)
        {
            if (view != null && !_cardImageStorage.ContainsKey(id))
            {
                _cardImageStorage.Add(id, view);
            }
        }

        public static Image GetCardImage(int id)
        {
            if (!_cardImageStorage.ContainsKey(id))
            {
                return null;
            }

            return _cardImageStorage[id];
        }
    }
}
