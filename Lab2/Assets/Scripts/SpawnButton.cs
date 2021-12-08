using System;
using UnityEngine;
using UnityEngine.UI;
namespace DefaultNamespace
{
    internal sealed class SpawnButton : MonoBehaviour, IDisposable
    {   
        [SerializeField] private Button _button = default;
        [SerializeField] private StickerSpawner _spawner = default;

        private void Awake()
        {
            _button.onClick.AddListener(ClickHandler);
        }

        private void ClickHandler()
        {
            _spawner.SpawnSticker();
        }
        
        public void Dispose()
        {
            _button.onClick.RemoveListener(ClickHandler);
        }
    }
}