using System;
using DefaultNamespace;
using UnityEngine;

public class StickerSpawner : MonoBehaviour
{
   [SerializeField] private Sticker _stickerPrefab;
   [SerializeField] private Canvas _parent;
   [SerializeField] private StickerStorage _storage;

   internal event Action<Sticker> OnSpawned;
   
   internal Sticker SpawnSticker()
   {
      var sticker = Instantiate(_stickerPrefab, _parent.transform);
      
      sticker.Initialize(_storage);

      OnSpawned?.Invoke(sticker);

      return sticker;
   }
}
