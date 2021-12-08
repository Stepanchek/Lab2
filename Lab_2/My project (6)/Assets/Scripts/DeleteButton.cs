using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour, IDisposable
{
    [SerializeField] private Button _button = default;
    [SerializeField] private Sticker _sticker = default;

    private void Awake()
    {
        _button.onClick.AddListener(_sticker.Delete);
    }
    
    public void Dispose()
    {
        _button.onClick.RemoveListener(_sticker.Delete);
    }
}
