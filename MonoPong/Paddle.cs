using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoPong {
    class Paddle {
        // Public Variabels
        public Texture2D paddleTexture { get; set; }
        public Rectangle paddleRect;

        // Private Varibales
        private Vector2 velocity;
        private float speed;
        private bool useArrows;
        private bool isComputer;

        // Public Objects

        // Private Objects
        GraphicsDeviceManager graphics;

        public Paddle(Texture2D texture, Vector2 initialPos, GraphicsDeviceManager _graphics, bool _useArrows, bool _isComputer = false) {
            graphics = _graphics;
            paddleTexture = texture;
            paddleRect = new Rectangle((int)initialPos.X, (int)initialPos.Y, 25, 150);
            speed = 5f;
            velocity = Vector2.Zero;
            useArrows = _useArrows;
            isComputer = _isComputer;
        }

        public void Update(GameTime gameTime, int ballYPos) {
            var kstate = Keyboard.GetState();

            if (paddleRect.Y + paddleRect.Height / 2 > ballYPos) {
                velocity.Y = -(int)(speed * 1.0);
            } else if (paddleRect.Y + paddleRect.Height / 2 < ballYPos) {
                velocity.Y = (int)(speed * 1.0);
            }

            // Make sure player isn't clipping
            if (paddleRect.Y < 0) {
                paddleRect.Y = 0;
                velocity.Y = 0;
            }
            if (paddleRect.Y + paddleRect.Height > graphics.PreferredBackBufferHeight) {
                paddleRect.Y = graphics.PreferredBackBufferHeight - paddleRect.Height;
                velocity.Y = 0;
            }

            paddleRect.Y += (int)velocity.Y;
            paddleRect.X += (int)velocity.X;
        }
        public void Update(GameTime gameTime) {
            var kstate = Keyboard.GetState();

            // Player Movement
            if (useArrows) {
                if (kstate.IsKeyDown(Keys.Up)) {
                    velocity.Y = -speed;
                } else if (kstate.IsKeyDown(Keys.Down)) {
                    velocity.Y = speed;
                } else {
                    velocity.Y = 0;
                }
            } else {
                if (kstate.IsKeyDown(Keys.W)) {
                    velocity.Y = -speed;
                } else if (kstate.IsKeyDown(Keys.S)) {
                    velocity.Y = speed;
                } else {
                    velocity.Y = 0;
                }
            }


            // Make sure player isn't clipping
            if (paddleRect.Y < 0) {
                paddleRect.Y = 0;
                velocity.Y = 0;
            }
            if (paddleRect.Y + paddleRect.Height > graphics.PreferredBackBufferHeight) {
                paddleRect.Y = graphics.PreferredBackBufferHeight - paddleRect.Height;
                velocity.Y = 0;
            }

            paddleRect.Y += (int)velocity.Y;
            paddleRect.X += (int)velocity.X;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Begin();
            spriteBatch.Draw(paddleTexture, paddleRect, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetRact() {
            return paddleRect;
        }

    }
}
