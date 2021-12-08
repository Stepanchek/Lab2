using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace DefaultNamespace
{
    internal sealed class StickerSaveController : MonoBehaviour
    {
        [SerializeField] private StickerStorage _storage = default;
        [SerializeField] private StickerSpawner _spawner = default;

        private const string KEY = "Stickers";

        private void Start()
        {
            Load();
        }

        private void Save()
        {
            var storage = _storage.Storage;
            var stickerData = new List<StickerData>(storage.Count);
            
            foreach (var sticker in storage)
                stickerData.Add(new StickerData(sticker));

            var data = JsonConvert.SerializeObject(stickerData);

            PlayerPrefs.SetString(KEY, data);
        }

        private void Load()
        {
            if (PlayerPrefs.HasKey(KEY) == false)
                return;
            
            var data = PlayerPrefs.GetString(KEY);
            var stickerData = JsonConvert.DeserializeObject<List<StickerData>>(data);

            foreach (var sticker in stickerData)
            {
                var stickerInstance = _spawner.SpawnSticker();
                
                sticker.Resolve(stickerInstance);
            }
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}