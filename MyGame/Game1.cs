﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D pixel;
    private Rectangle MyRectangle;
    private Vector2 ballPosition;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ballPosition = new Vector2(0, 0);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        pixel =  new Texture2D(GraphicsDevice, 1, 1);
        pixel.SetData<Color>(new Color [] {Color.White});

        MyRectangle = new Rectangle(0, 0, 300, 300);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Up))
        {
            ballPosition.Y -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(pixel, ballPosition, MyRectangle, Color.Red);
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}
