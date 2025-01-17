﻿using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using System.Collections.Generic;
using System.Linq;
using System;
using static Terraria.ModLoader.ModContent;
using System.Reflection;
using SpiritMod.Effects;

namespace SpiritMod.Prim
{
    public class PrimTrailManager
	{
		public static int DrawProjectile = 1;
		public static int DrawNPC = 2;
		public List<PrimTrail> _trails = new List<PrimTrail>();
        public void DrawTrailsNPC(SpriteBatch spriteBatch)
        {
            foreach (PrimTrail trail in _trails.ToArray().Where(x => x._drawtype == DrawNPC))
            {
                trail.Draw();
            }
        }
		public void DrawTrailsProj(SpriteBatch spriteBatch)
		{
			foreach (PrimTrail trail in _trails.ToArray().Where(x => x._drawtype == DrawProjectile)) {
				trail.Draw();
			}
		}
		public void UpdateTrails()
        {
            foreach (PrimTrail trail in _trails.ToArray())
            {
                trail.Update();
            }
        }
        public void CreateTrail(PrimTrail PT) => _trails.Add(PT);

    }
    public partial class PrimTrail
    {
        protected bool _destroyed = false;
        protected Projectile _projectile = null;
        protected NPC _npc = null;
		protected int _entitytype;
		public int _drawtype = 0;
        protected float _width;
        protected float _alphaValue;
        protected int _cap;
        protected ITrailShader _trailShader;
        protected int _counter;
        protected int _noOfPoints;
        protected Color _color = new Color(255, 255, 255);
        protected List<Vector2> _points = new List<Vector2>();

        protected GraphicsDevice _device;
        protected Effect _effect;
        protected BasicEffect _basicEffect;

        protected VertexPositionColorTexture[] vertices;
        protected int currentIndex;
        public PrimTrail()
        {
            _trailShader = new DefaultShader();
            _device = Main.graphics.GraphicsDevice;
            _basicEffect = new BasicEffect(_device);
            _basicEffect.VertexColorEnabled = true;
            SetDefaults();
            vertices = new VertexPositionColorTexture[_cap];
        }


        public void Dispose()
        {
            SpiritMod.primitives._trails.Remove(this);
        }
        public void Update()
        {
            OnUpdate();
        }
        public virtual void OnUpdate()
        {

        }
        public void Draw()
        {
            vertices = new VertexPositionColorTexture[_noOfPoints];
            currentIndex = 0;

            PrimStructure(Main.spriteBatch);
            SetShaders();
            if (_noOfPoints >= 1)
            {
                _device.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, _noOfPoints / 3);
            }
        }
        public virtual void PrimStructure(SpriteBatch spriteBatch)
        {

        }
        public virtual void SetShaders()
        {

        }
        public virtual void SetDefaults()
        {

        }

        public virtual void OnDestroy()
        {

        }
        //Helper methods
    }
}