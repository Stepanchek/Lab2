using System;
using System.Globalization;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public sealed class StickerData
    {
        [SerializeField] public string Text;
        [SerializeField] public Vector2Data Position;
        [SerializeField] public string Time;

        internal StickerData() {}

        internal StickerData(Sticker sticker)
        {
            Text = sticker.Text;
            Position = new Vector2Data(sticker.Root.position);
            Time = sticker.DateTime.ToString(CultureInfo.InvariantCulture);
        }

        internal void Resolve(Sticker sticker)
        {
            sticker.Text = Text;
            sticker.Root.position = Position.ToVector();
            sticker.SetTime(DateTime.Parse(Time));
        }
    }
}