using System;
using System.Collections.Generic;
using System.Text;
using FontStashSharp;
using Microsoft.Xna.Framework.Graphics;

namespace Undine.FontStashSharp
{
    public struct FontStashSharpComponent
    {
        public SpriteFontBase Font;
        public string Text;
        public int CharacterSpacing;
        public int LineSpacing;
        public TextStyle TextStyle;
        public FontSystemEffect FontSystemEffect;
        public int EffectAmount;
    }
}