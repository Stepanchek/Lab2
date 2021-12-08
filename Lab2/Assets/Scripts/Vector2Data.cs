using System;
using UnityEngine;
namespace DefaultNamespace
{
    [Serializable]
    public class Vector2Data
    {
        [SerializeField] public float x;
        [SerializeField] public float y;

        public Vector2Data(Vector2 vector2)
        {
            x = vector2.x;
            y = vector2.y;
        }

        public Vector2 ToVector()
        {
            return new(x, y);
        }
    }
}