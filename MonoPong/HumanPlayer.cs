using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoPong {
    class HumanPlayer : Player {

        public HumanPlayer(Texture2D _texture, Vector2 _pos, GraphicsDeviceManager _graphics) : base(_texture, _pos, _graphics) {
        }

        public override double MovePlayer(GameTime gameTime) {
            var kstate = Keyboard.GetState();

            // Player Movement
            if (kstate.IsKeyDown(Keys.Up)) {
                return -speed * gameTime.ElapsedGameTime.TotalSeconds;
            } else if (kstate.IsKeyDown(Keys.Down)) {
                return speed * gameTime.ElapsedGameTime.TotalSeconds;
            } else {
                return 0;
            }
        }
    }
}
