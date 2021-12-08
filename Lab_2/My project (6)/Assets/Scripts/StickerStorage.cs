using System;
using System.Collections.Generic;
using UnityEngine;
namespace DefaultNamespace
{
    internal sealed class StickerStorage : MonoBehaviour, IDisposable
    {
        [SerializeField] private StickerSpawner _stickerSpawner = default;

        private List<Sticker> _storage = new List<Sticker>();

        internal List<Sticker> Storage => _storage;
        
        private void Awake()
        {
            _stickerSpawner.OnSpawned += SpawnHandler;
        }

        private void SpawnHandler(Sticker sticker)
        {
            _storage.Add(sticker);
        }

        internal void Delete(Sticker sticker)
        {
            _storage.Remove(sticker);

            Destroy(sticker.gameObject);
        }
        public void Dispose()
        {
            _stickerSpawner.OnSpawned -= SpawnHandler;
        }
    }
}