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
    public class RequestGenerator
    {
        public EventHandler<RequestEventArgs> OnEnd;
        
        public async Task SendGetTextureRequest(string url)
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
                var texture = DownloadHandlerTexture.GetContent(request);
                
                OnEnd?.Invoke(this, new RequestEventArgs(texture));
            }
        }
    }
}