using System;
using TMPro;
using UnityEngine;

namespace RubiusImage.Interface.Dropdown
{
    public class LoadTypeDropdownController : MonoBehaviour
    {
        public Action OnAllAtOnceButton;
        public Action OnOneByOneButton;
        public Action OnWhenImageReadyButton;

        [SerializeField] private TextMeshProUGUI labelText;
        
        public void AllAtOnceButton()
        {
            labelText.text = "All at once";
            OnAllAtOnceButton?.Invoke();
        }

        public void OneByOneButton()
        {
            labelText.text = "One by one";
            OnOneByOneButton?.Invoke();
        }

        public void WhenImageReadyButton()
        {
            labelText.text = "When image ready";
            OnWhenImageReadyButton?.Invoke();
        }
    }
}
