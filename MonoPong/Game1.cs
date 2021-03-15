using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoPong {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D paddleTexture;
        private Texture2D ballTexture;
        private SpriteFont scoreFont;

        //private Paddle player1;
        //private Paddle player2;

        private HumanPlayer player1;
        private AIPlayer player2;

        private Ball ball;

        private int player1Score = 0;
        private int player2Score = 0;

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Window.Title = "MonoPong";
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            // TODO: use this.Content to load your game content here
            paddleTexture = Content.Load<Texture2D>("paddle");
            ballTexture = Content.Load<Texture2D>("ball");
            scoreFont = Content.Load<SpriteFont>("Score");

            // Initalize ball first becauase we refernce it in player2
            ball = new Ball(ballTexture, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), _graphics);

            player1 = new HumanPlayer(paddleTexture, new Vector2(50, _graphics.PreferredBackBufferHeight / 2), _graphics);
            player2 = new AIPlayer(paddleTexture, new Vector2(_graphics.PreferredBackBufferWidth - 50 - paddleTexture.Width, _graphics.PreferredBackBufferHeight / 2), _graphics, ball);

        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player1.Update(gameTime);
            player2.Update(gameTime);
            //player2.Update(gameTime);
            ball.Update(gameTime, player1.GetRect(), player2.GetRect());

            if (ball.OutOfBounds() == 1) {
                player2Score += 1;
                ball.Reset();
            }
            if (ball.OutOfBounds() == 2) {
                player1Score += 1;
                ball.Reset();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            ball.Draw(_spriteBatch);
            player1.Draw(_spriteBatch);
            player2.Draw(_spriteBatch);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(scoreFont, "P1: " + player1Score, new Vector2(10, 10), Color.Black);
            _spriteBatch.DrawString(scoreFont, "P2: " + player2Score, new Vector2(_graphics.PreferredBackBufferWidth - 50, 10), Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
