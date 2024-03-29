﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Undine.Core;
using Undine.MonoGame;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using FontStashSharp;

namespace Undine.FontStashSharp
{
    public class FontStashSharpSystem : UnifiedSystem<FontStashSharpComponent, TransformComponent, ColorComponent>
    {
        public FontStashSharpSystem(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
        }

        public SpriteBatch SpriteBatch { get; }

        private Vector2 normalizedOrigin = new Vector2(0.5f, 0.5f);

        public override void ProcessSingleEntity(int entityId, ref FontStashSharpComponent a, ref TransformComponent b, ref ColorComponent c)
        {
            var size = a.Font.MeasureString(a.Text) * b.Scale;
            SpriteBatch.DrawString(
                font: a.Font,
                text: a.Text,
                position: b.Position,
                color: c.Color,
                scale: b.Scale,
                rotation: b.Rotation,
                origin: size * normalizedOrigin,
                layerDepth: 0f,
                characterSpacing: a.CharacterSpacing,
                lineSpacing: a.LineSpacing,
                textStyle: a.TextStyle,
                effect: a.FontSystemEffect,
                effectAmount: a.EffectAmount
                );
        }

        public override void PreProcess()
        {
            SpriteBatch.Begin();
        }

        public override void PostProcess()
        {
            SpriteBatch.End();
        }
    }
}