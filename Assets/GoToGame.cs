using UnityEngine;
using System.Collections;

public class GoToGame : MonoBehaviour {

    public void startGame()
    {
        Debug.Log("LOAD SCENE 1");
        CharacterMovemenetController.lives = 3;
        CharacterMovemenetController.hp = 100;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
