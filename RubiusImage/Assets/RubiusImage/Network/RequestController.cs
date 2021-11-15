using System;
using RubiusImage.Interface;
using RubiusImage.Interface.Dropdown;
using UnityEngine;

namespace RubiusImage.Network
{
    public class RequestController : MonoBehaviour
    {
        [SerializeField] private InterfaceController interfaceController;
        [SerializeField] private AddressConfig addressConfig;
        
        private NetworkController netController;
        
        private void Start()
        {
           // netController = new NetworkController(addressConfig);

           // loadTypeDropdownController.OnAllAtOnceButton += netController.AllAtOnce;
           // loadTypeDropdownController.OnOneByOneButton += netController.OneByOne;
           // loadTypeDropdownController.OnWhenImageReadyButton += netController.WhenImageReady;
        }
    }
}
