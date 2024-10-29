using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PWinLoseScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool hasArt = false;
    public double deathTime = 60;
    public TextMeshProUGUI dText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasArt)
        {
            deathTime -= Time.deltaTime;
            dText.text = "Station Collapse in " + (int)deathTime + " seconds.";
            if (deathTime <= 0)
            {
                SceneManager.LoadScene("LoseScene");
            }
        }
    }
}
