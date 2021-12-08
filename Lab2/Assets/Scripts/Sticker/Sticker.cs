using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    internal sealed class Sticker : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField = default;
        [SerializeField] private Transform _root = default;
        [SerializeField] private TextMeshProUGUI _dateField = default;

        private StickerStorage _storage;
        private DateTime _dateTime;
        
        internal string Text
        {
            get => _inputField.text;
            set => _inputField.text = value;
        }
        internal Transform Root => _root;
        internal DateTime DateTime => _dateTime;

        internal void Initialize(StickerStorage storage)
        {
            _storage = storage;
            
            SetTime(DateTime.Now);
        }

        internal void SetTime(DateTime dateTime)
        {
            _dateTime = dateTime;
            _dateField.text = dateTime.ToString(CultureInfo.InvariantCulture);
        }

        internal void Delete()
        {
            _storage.Delete(this);
        }
    }
}