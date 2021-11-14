using System;
using UnityEngine.UI;

namespace RubiusImage.Network
{
    public class RequestEventArgs : EventArgs
    {
        public Image Image;

        public RequestEventArgs(Image image)
        {
            Image = image;
        }
    }
}