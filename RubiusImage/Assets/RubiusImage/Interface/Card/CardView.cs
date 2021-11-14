using UnityEngine;
using UnityEngine.UI;

namespace RubiusImage.Interface.Card
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private int id;
        [SerializeField] private Image cardImage;

        private void Start()
        {
            CardStorage.CardRegistered(id, cardImage);
        }
    }
}
