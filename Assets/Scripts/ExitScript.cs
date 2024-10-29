using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PWinLoseScript pscript = other.GetComponent<PWinLoseScript>();
        if(pscript != null && pscript.hasArt == true)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
