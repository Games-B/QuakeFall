using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Misc;

public class PauseGame : MonoBehaviour
{

    public Transform Canvas;
    public Transform Player;
    [SerializeField] private CursorLock _cursorLock;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {

        if (Canvas.gameObject.activeInHierarchy == false)
        {
            Canvas.gameObject.SetActive(true);
            _cursorLock.enabled = false;
            Time.timeScale = 0;
            //Player.GetComponent<PlayerCamera>().enabled = false;

        }
        else
        {
            Canvas.gameObject.SetActive(false);
            _cursorLock.enabled = true;
            Time.timeScale = 1;
            //Player.GetComponent<PlayerCamera>().enabled = true;
        }
    }
}