using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int score;
    public GameObject pauseMenu;

    // Variable to keep track of what level we are on
    private string CurrentLevelName = string.Empty;

    private StarterAssets.StarterAssetsInputs playerInput;
    private StarterAssets.FirstPersonController firstPersonController;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerInput = player.GetComponent<StarterAssets.StarterAssetsInputs>();
            firstPersonController = player.GetComponent<StarterAssets.FirstPersonController>();
        }
    }

    /*#region This code makes this class a Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // Make sure this game manager persists across scenes
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second" + "instance of singleton Game Manager!");
        }

    }
    #endregion*/

    // Methods to load and unload scenes
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }

        CurrentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName);
            return;
        }
    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + CurrentLevelName);
            return;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerInput.enabled = false;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerInput.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0f)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

}
