using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void OnGoLobby()
    {
        SceneChange.Instance.Change("Lobby");
        
    }
    public void OnGoGame()
    {
        SceneChange.Instance.Change("Game");
    }
    public void OnGoEnd()
    {
        SceneChange.Instance.Change("End");
    }
}
