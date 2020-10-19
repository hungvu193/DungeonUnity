using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake() {
        if (GameManager.instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // resources game
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //Reference
    public Player player;

    // global Floating Text
    public FloatingTextManager floatingTextManager;

    //Logic
    public int pesos;
    public int experience;
    // Save State
    /*
     * INT prefered skin
     * INT pesos
     * INT experience
     * INT weaponLevel
    */
    public void SaveState() {
        string s = "";
        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";
        PlayerPrefs.SetString("SaveState",s);

    }

    public void LoadState(Scene scene, LoadSceneMode mode) {
        Debug.Log("Load State");
        if (!PlayerPrefs.HasKey("SaveSate")) {
            return;
        }
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
    }

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 mention, float duration) {
        floatingTextManager.Show(msg, fontSize, color, position, mention, duration);
    }
}
