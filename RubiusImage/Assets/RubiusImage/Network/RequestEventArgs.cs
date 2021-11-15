using System;
using UnityEngine;
using UnityEngine.UI;

namespace RubiusImage.Network
{
    public class RequestEventArgs : EventArgs
    {
        public Texture2D Texture2D;

        public RequestEventArgs(Texture2D texture2D)
        {
            Texture2D = texture2D;
        }
    }
}