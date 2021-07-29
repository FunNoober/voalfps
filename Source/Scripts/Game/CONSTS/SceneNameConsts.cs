using UnityEngine.SceneManagement;

public static class SceneNameConsts
{
    public static string MENU_NAME = "MainMenu";
    public static string TUTORIAL_NAME = "TutorialLevel";
    public static string LEVEL_1_NAME = "Level1";
    public static string LEVEL_2_NAME = "Level2";
    public static string LEVEL_3_NAME = "Level3";
    public static string LEVEL_4_NAME = "Level4";

    public static void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
