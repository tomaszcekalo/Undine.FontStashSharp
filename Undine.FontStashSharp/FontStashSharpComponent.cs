using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Undine.FontStashSharp
{
    public struct FontStashSharpComponent
    {
        public SpriteFont Font { get; internal set; }
        public string Text { get; internal set; }
    }
}