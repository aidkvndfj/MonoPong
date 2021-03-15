using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoPong {
    class AIPlayer : Player {

        Ball playBall;

        public AIPlayer(Texture2D _texture, Vector2 _pos, GraphicsDeviceManager _graphics, Ball _playBall) : base(_texture, _pos, _graphics) {
            playBall = _playBall;
        }

        public override double MovePlayer(GameTime gameTime) {
            if (playerRect.Y + playerRect.Height / 2 > playBall.GetYPos()) {
                return -speed * 1.0 * gameTime.ElapsedGameTime.TotalSeconds;
            } else if (playerRect.Y + playerRect.Height / 2 < playBall.GetYPos()) {
                return speed * 1.0 * gameTime.ElapsedGameTime.TotalSeconds;
            }
            return 0;
        }
    }
}
