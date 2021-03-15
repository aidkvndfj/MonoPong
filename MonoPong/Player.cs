using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MonoPong {
    abstract class Player {
        public Texture2D playerTexture { get; set; }
        public Rectangle playerRect;

        public Vector2 velocity;
        public GraphicsDeviceManager graphics;

        public double speed;

        public Player(Texture2D _texture, Vector2 _pos, GraphicsDeviceManager _graphics) {
            playerTexture = _texture;
            playerRect = new Rectangle((int)_pos.X, (int)_pos.Y, playerTexture.Width, playerTexture.Height * 2);
            graphics = _graphics;

            velocity = Vector2.Zero;
            speed = 300f;
        }

        public void Update(GameTime gameTime) {
            velocity.Y = (float)MovePlayer(gameTime);
            velocity.X = 0f;

            CheckClipping();

            playerRect.Y += (int)velocity.Y;
            playerRect.X += (int)velocity.X;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Begin();
            spriteBatch.Draw(playerTexture, playerRect, Color.White);
            spriteBatch.End();
        }

        public void CheckClipping() {
            // Make sure player isn't clipping
            if (playerRect.Y < 0) {
                playerRect.Y = 0;
                velocity.Y = 0;
            }
            if (playerRect.Y + playerRect.Height > graphics.PreferredBackBufferHeight) {
                playerRect.Y = graphics.PreferredBackBufferHeight - playerRect.Height;
                velocity.Y = 0;
            }
        }

        public Rectangle GetRect() {
            return playerRect;
        }

        public abstract double MovePlayer(GameTime gameTime);

    }
}
