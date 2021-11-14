using UnityEngine;

namespace RubiusImage.Network
{
    [CreateAssetMenu(fileName = "AddressConfig", menuName = "AddressConfig")]
    public class AddressConfig : ScriptableObject
    {
        public string RequestAddress;
    }
}