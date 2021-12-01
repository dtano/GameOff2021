using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float transitionTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadNextLevel()
    {
        StartCoroutine(SoundManager.Instance.FadeMusicOut(transitionTime));
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("LeaveScene");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
