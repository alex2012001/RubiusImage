using System;
using RubiusImage.Interface.Card;
using RubiusImage.Interface.Dropdown;
using UnityEngine;

namespace RubiusImage.Interface
{
    public class InterfaceController : MonoBehaviour
    {
        public EventHandler<InterfaceOnLoadEventArgs> OnLoad;
        
        [SerializeField] private LoadTypeDropdownController loadTypeDropdownController;

        private bool _isLoad;
        private LoadTypes _loadType;
        
        public void Load()
        {
            _isLoad = true;
            OnLoad?.Invoke(this, new InterfaceOnLoadEventArgs(_loadType));
        }

        public void ResetCardAnimation()
        {
            if (_isLoad)
            {
                CardStorage.ResetAnimation();
            }
        }
        
        private void Start()
        {
            loadTypeDropdownController.OnAllAtOnceButton += SetAllAtOnce;
            loadTypeDropdownController.OnOneByOneButton += OneByOneButton;
            loadTypeDropdownController.OnWhenImageReadyButton += WhenImageReadyButton;
        }

        private void SetAllAtOnce()
        {
            _loadType = LoadTypes.AllAtOnce;
        }
        
        private void OneByOneButton()
        {
            _loadType = LoadTypes.OneByOne;
        }
        
        private void WhenImageReadyButton()
        {
            _loadType = LoadTypes.WhenImageReady;
        }
    }
}
