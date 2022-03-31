
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Minesweeper.Scenes
{
	public class SceneManager
	{
		private Scene currentScene;

		public SceneManager(ContentManager content, SpriteBatch spriteBatch, SceneID sceneID = SceneID.Title)
		{
			Scene scene = GetScenefromID(content, spriteBatch, sceneID);
			SetScene(scene);
		}

		public Scene GetCurrentScene()
		{
			return currentScene;
		}

		public Scene SetScene(ContentManager content, SpriteBatch spriteBatch, SceneID sceneID)
		{
			Scene nextScene = GetScenefromID(content, spriteBatch, sceneID);
			currentScene = nextScene;
			return currentScene;
		}

		public Scene SetScene(Scene scene)
		{
			currentScene = scene;
			return currentScene;
		}

		public static Scene GetScenefromID(ContentManager content, SpriteBatch spriteBatch, SceneID sceneID)
        {
            return sceneID switch
            {
                SceneID.MakeBoard => new TitleScreen(content, spriteBatch),
                SceneID.Board => new TitleScreen(content, spriteBatch),
                _ => new TitleScreen(content, spriteBatch),
            };
        }
    }
}