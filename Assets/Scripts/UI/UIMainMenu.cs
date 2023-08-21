using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMainMenu : MonoBehaviour
{


    // The SerializerField attribute indicated that a private variable should still be shown in Unity Editor's Inspector window, allowing you to assign a value without making it public
    // The field is type Button and named _StartButton
    [SerializeField] Button _StartButton;

    // Start is called before the first frame update
    void Start()
    {
        // We add an on click event listener to _StartButton which runs StartGame
        _StartButton.onClick.AddListener(StartGame);

    }

    // Private here means that this method can only be accessed from within this class and not from outside
    // Void here means the method doesn't return any value
    private void StartGame()
    {
        // This accesses a static instance of the ScenesManager class, calls the method LoadScene and passes ScenesManager.Scene.Level enum as an argument
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Level);
    }
}
