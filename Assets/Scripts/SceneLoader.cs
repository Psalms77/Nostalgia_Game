using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator sceneAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void close_game()
    {
        Application.Quit();
    }

    public void load_scene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void load_next_scene()
    {
        //insert animation
        StartCoroutine(load_scene_fade());
    }

    IEnumerator load_scene_fade()
    {
        sceneAnim.SetTrigger("LoadScene");

        yield return new WaitForSeconds(2f);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex + 1 > SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }


}
