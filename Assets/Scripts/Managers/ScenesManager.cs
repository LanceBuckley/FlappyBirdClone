using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // This line declares a static instance variable named Instance within the ScenesManager
    // This is a common approach called the Singleton pattern, ensuring that there's only one instance of the ScenesManager throughout the application.
    public static ScenesManager Instance;

    // The Awake() method is a Unity callback that runs when the object is initialized
    // In this case, it assigns the current instance of the ScenesManager to the Instance variable, making it accessible as a singleton instance.
    private void Awake()
    {
        Instance = this;
    }

    // An immutable list of scenes. Must be in the same order as in the build manager. Don't forget to add new scenes here!
    public enum Scene
    {
        StartMenu,
        Level
    }

    public void LoadScene(Scene scene)
    {
        // Grab the Unity SceneManager, not your custom class, and use the LoadScene method, passing scene as an argument
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNextScene()
    {
        // Passes the next scene in the build order by using the GetActiveScene method to grab the current scene, access its buildIndex property and add 1 to it
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
