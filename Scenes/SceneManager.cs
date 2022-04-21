
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Minesweeper.Scenes
{
	public class SceneManager
	{
		private Scene currentScene;
		

		public SceneManager(ContentManager content, SpriteBatch spriteBatch, SceneID sceneID = SceneID.Title)
		{
			
		}
		public void Draw(SpriteBatch spritebatch)
        {
			currentScene.Draw(spritebatch);
			
        }
		public void Update(Vector2 clickpos)
        {
			currentScene.Update(clickpos);
        }

		public Scene GetCurrentScene()
		{
			return currentScene;
		}

		public Scene SetScene(Scene scene)
		{
			if (!(currentScene is null)) currentScene.Unload();
			currentScene = scene;
			currentScene.Load();
			return currentScene;
		}
    }
}