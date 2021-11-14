using System;
using System.Collections;
using System.ComponentModel;
using System.Threading.Tasks;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

namespace RubiusImage.Network
{
    public class RequestGenerator : MonoBehaviour
    {
        public EventHandler<RequestEventArgs> OnEnd;
        
        public Image _image;

        private void Start()
        {
            SendRequest("https://picsum.photos/200/300");
        }

        public async Task SendRequest(string url)
        {
            var request = UnityWebRequestTexture.GetTexture(url);
            var operation = request.SendWebRequest();

            while (!operation.isDone)
            {
                await Task.Yield();
            }

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                var _texture = DownloadHandlerTexture.GetContent(request);
                _image.sprite = Sprite.Create(_texture, 
                    new Rect(0f, 0f, _texture.width, _texture.height),
                    new Vector2(0.5f,0.5f));
            }
            
            OnEnd?.Invoke(this, new RequestEventArgs(_image));
        }
    }
}