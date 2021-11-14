using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

namespace RubiusImage.Network
{
    public class NetworkController : MonoBehaviour
    {
        [SerializeField] private AddressConfig addressConfig;
        public Image Image;
        //public RequestGenerator RequestGenerator;
        private void Start()
        {
            
            //var requestGenerator = new RequestGenerator();
            //requestGenerator.OnEnd += Test;
          //  RequestGenerator.SendRequest("https://picsum.photos/200/300");
            
        }

        public void Test(object sender, RequestEventArgs e)
        {
            Image = e.Image;
        }
    }
}
