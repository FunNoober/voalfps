using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DevConsole : MonoBehaviour
{
    public const string ENABLE_CHEATS_COMMAND = "/developer.keyboard.cheats.enabled";
    public const string HELP_COMMAND = "/help";

    public const string AMMO_COMMAND = "/give.ammo";
    public const string HEALTH_COMMAND = "/give.health";
    public const string DISABLE_HEALTH_COMMAND = "/take.health";

    public const string QUIT_GAME_COMMAND = "/application.game.quit";

    public static event Action giveAmmoAction;
    public static event Action giveHealthAction;
    public static event Action takeHealthAction;

    public InputField field;
    public GameObject helpLabel;

    private bool cheatsEnabled;
    private bool helpEnabled;

    private void Awake()
    {
        field = transform.GetChild(0).GetComponent<InputField>();
    }

    public void GetCommand(string actionPassed)
    {
        if(actionPassed == ENABLE_CHEATS_COMMAND) { EnableCheatCommands(); }

        if(actionPassed == HELP_COMMAND)
        {
            field.text = "";
            if(helpEnabled == true)
            {
                helpEnabled = false;
                helpLabel.SetActive(false);
                return;
            }

            if(helpEnabled == false)
            {
                helpEnabled = true;
                helpLabel.SetActive(true);
                return;
            }
        }

        if (cheatsEnabled == true)
        {
            if (actionPassed == AMMO_COMMAND)
            {
                if (giveAmmoAction != null)
                    giveAmmoAction();
            }

            if (actionPassed == HEALTH_COMMAND)
            {
                if (giveHealthAction != null)
                    giveHealthAction();
            }

            if (actionPassed == DISABLE_HEALTH_COMMAND)
            {
                if (takeHealthAction != null)
                    takeHealthAction();
            }

            if(actionPassed == QUIT_GAME_COMMAND)
            {
                field.text = "";
                Debug.Log("Quit");
                Application.Quit();
                return;
            }
        }


        field.text = "";
    }

    public void EnableCheatCommands()
    {
        cheatsEnabled = true;
    }
}
