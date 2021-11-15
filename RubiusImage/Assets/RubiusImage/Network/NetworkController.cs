using RubiusImage.Interface.Card;
using UnityEngine;

namespace RubiusImage.Network
{
    public class NetworkController
    {
        private int _counter;
        private readonly AddressConfig _addressConfig;

        public NetworkController(AddressConfig addressConfig)
        {
            _addressConfig = addressConfig;
        }

        public void WhenImageReady()
        {
            for (int i = 0; i < 5; i++)
            {
                var requestGenerator = new RequestGenerator();
                requestGenerator.OnEnd += ((sender, args) =>
                {
                    var card = CardStorage.GetCardImage(_counter);
                    _counter++;
                    
                    card.cardImage.sprite = Sprite.Create(args.Texture2D, 
                        new Rect(0f, 0f, args.Texture2D.width, args.Texture2D.height),
                        new Vector2(0.5f,0.5f));
                    
                    card.OnAnimReady?.Invoke();
                    
                    if (_counter == 5)
                    {
                        _counter = 0;
                    }
                });
                
                requestGenerator.SendGetTextureRequest(_addressConfig.RequestAddress);
            }
        }

        public void AllAtOnce()
        {
            RequestEventArgs[] requestEventArgs = new RequestEventArgs[5];
            
            for (int i = 0; i < 5; i++)
            {
                var requestGenerator = new RequestGenerator();
                requestGenerator.OnEnd += ((sender, args) =>
                {
                    requestEventArgs[_counter] = args;
                    _counter++;
                    
                    if (_counter >= 5)
                    {
                        _counter = 0;
                        for (int j = 0; j < 5; j++)
                        {
                            var card = CardStorage.GetCardImage(_counter);
                            _counter++;
                            
                            card.cardImage.sprite = Sprite.Create(requestEventArgs[j].Texture2D, 
                                new Rect(0f, 0f, requestEventArgs[j].Texture2D.width, 
                                    requestEventArgs[j].Texture2D.height),
                                new Vector2(0.5f,0.5f));
                            
                            card.OnAnimReady?.Invoke();
                        }

                        _counter = 0;
                    }
                });
                
                requestGenerator.SendGetTextureRequest(_addressConfig.RequestAddress);
            }
        }

        public void OneByOne()
        {
            var requestGenerator = new RequestGenerator();
            requestGenerator.OnEnd += ((sender, args) =>
            {
                var card = CardStorage.GetCardImage(_counter);
                _counter++;
                
                card.cardImage.sprite = Sprite.Create(args.Texture2D, 
                    new Rect(0f, 0f, args.Texture2D.width, args.Texture2D.height),
                    new Vector2(0.5f,0.5f));

                card.OnAnimReady?.Invoke();
                
                if (_counter < 5)
                {
                    OneByOne();
                }
                else
                {
                    _counter = 0;
                }
            });
            
            requestGenerator.SendGetTextureRequest(_addressConfig.RequestAddress);
        }
    }
}
