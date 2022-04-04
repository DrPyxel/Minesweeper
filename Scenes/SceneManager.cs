
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Minesweeper.Clickables;

namespace Minesweeper.Scenes
{
	public class SceneManager
	{
		private Scene currentScene;
		private ButtonManager buttonManager;

		public SceneManager(ContentManager content, SpriteBatch spriteBatch, SceneID sceneID = SceneID.Title)
		{
			Scene scene = GetScenefromID(this, content, spriteBatch, sceneID);
			buttonManager = new ButtonManager(content, spriteBatch);
			SetScene(scene);
		}
		public void Draw(SpriteBatch spritebatch)
        {
			GetCurrentScene().Draw(spritebatch);
			buttonManager.DrawButtons();
        }
		public void Update()
        {
			buttonManager.Update();
        }

		public void AddButton(IButton button)
        {
			buttonManager.AddButton(button);
        }
		public void RemoveButton(IButton button)
        {
			buttonManager.RemoveButton(button);
        }

		public Scene GetCurrentScene()
		{
			return currentScene;
		}

		public Scene SetScene(ContentManager content, SpriteBatch spriteBatch, SceneID sceneID)
		{
			Scene nextScene = GetScenefromID(this, content, spriteBatch, sceneID);
			currentScene = nextScene;
			return currentScene;
		}

		public Scene SetScene(Scene scene)
		{
			currentScene = scene;
			return currentScene;
		}

		public static Scene GetScenefromID(SceneManager sceneManager, ContentManager content, SpriteBatch spriteBatch, SceneID sceneID)
        {
            return sceneID switch
            {
                SceneID.MakeBoard => new TitleScreen(sceneManager, content, spriteBatch),
                SceneID.Board => new TitleScreen(sceneManager, content, spriteBatch),
                _ => new TitleScreen(sceneManager, content, spriteBatch),
            };
        }
    }
}