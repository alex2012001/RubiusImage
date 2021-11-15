using RubiusImage.Interface;
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
            netController = new NetworkController(addressConfig);
            
            interfaceController.OnLoad += SendRequest;
        }

        private void SendRequest(object sender, InterfaceOnLoadEventArgs args)
        {
            switch (args.LoadTypes)
            {
                case LoadTypes.AllAtOnce: 
                    netController.AllAtOnce();
                    break;
                case LoadTypes.OneByOne: 
                    netController.OneByOne();
                    break;
                case LoadTypes.WhenImageReady: 
                    netController.WhenImageReady();
                    break;
            }
        }
    }
}
