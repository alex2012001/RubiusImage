using RubiusImage.Interface;
using UnityEngine;

namespace RubiusImage.Network
{
    public class RequestController : MonoBehaviour
    {
        [SerializeField] private InterfaceController interfaceController;
        [SerializeField] private AddressConfig addressConfig;
        
        private NetworkController _netController;
        
        private void Start()
        {
            _netController = new NetworkController(addressConfig);
            
            interfaceController.OnLoad += SendRequest;
        }

        private void SendRequest(object sender, InterfaceOnLoadEventArgs args)
        {
            switch (args.LoadTypes)
            {
                case LoadTypes.AllAtOnce: 
                    _netController.AllAtOnce();
                    break;
                case LoadTypes.OneByOne: 
                    _netController.OneByOne();
                    break;
                case LoadTypes.WhenImageReady: 
                    _netController.WhenImageReady();
                    break;
            }
        }
    }
}
