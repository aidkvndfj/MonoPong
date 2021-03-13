using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoPong {
    class Ball {
        // Public Variabels
        public Texture2D ballTexture { get; set; }

        // Private Varibales
        private Vector2 velocity;
        private Rectangle ballRect;
        private float speed;

        // Public Objects

        // Private Objects
        GraphicsDeviceManager graphics;
        Random random;

        public Ball(Texture2D texture, Vector2 initialPos, GraphicsDeviceManager _graphics) {
            graphics = _graphics;
            ballTexture = texture;

            speed = 7f;

            random = new Random();
            ballRect = new Rectangle((int)initialPos.X, (int)initialPos.Y, 20, 20);
            velocity = new Vector2(speed, speed);
        }

        public void Update(GameTime gameTime, Rectangle paddle1, Rectangle paddle2) {
            var kstate = Keyboard.GetState();

            if (ballRect.Y < 0 || ballRect.Y + ballRect.Height > graphics.PreferredBackBufferHeight) {
                velocity.Y *= -1;
            }

            if (ballRect.Intersects(paddle1) || ballRect.Intersects(paddle2)) {
                velocity.X *= -1;
                velocity.Y += random.Next(-3, 3);
                if (velocity.Y < 3 && velocity.Y > 0)
                    velocity.Y = speed;
                if (velocity.Y > -3 && velocity.Y <= 0)
                    velocity.Y = -speed;

                if (velocity.Y > 10)
                    velocity.Y = speed;
                if (velocity.Y < -10)
                    velocity.Y = -speed;
            }

            ballRect.Y += (int)velocity.Y;
            ballRect.X += (int)velocity.X;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Begin();
            spriteBatch.Draw(ballTexture, ballRect, Color.White);
            spriteBatch.End();
        }

        public int OutOfBounds() {
            if (ballRect.X < 0) {
                return 1;
            } else if (ballRect.X > graphics.PreferredBackBufferWidth) {
                return 2;
            }
            return 0;
        }

        public int GetYPos() {
            return ballRect.Y + ballRect.Height / 2;
        }

        public void Reset() {
            ballRect.X = graphics.PreferredBackBufferWidth / 2;
            ballRect.Y = graphics.PreferredBackBufferHeight / 2;
            velocity.X *= -1;
            velocity.Y += random.Next(-1, 1);
        }
    }
}
