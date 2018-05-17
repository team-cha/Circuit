using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void ReloadScene()
    {
        MyLoadScene(SceneManager.GetActiveScene().name);
    }

    public void MyLoadScene(string name)
    {
        StartCoroutine(SceneLoading(name));
    }

    private IEnumerator SceneLoading(string name)
    {
        // 로딩 스크린 호출
        LoadingManager.instance.Loading(name + " Loading...");

        // 로딩 시간이 계산 안 된 경우 대기
        while(LoadingManager.instance.loadingTime == 0)
        {
            yield return null;
        }
        yield return new WaitForSeconds(LoadingManager.instance.loadingTime);

        SceneManager.LoadScene(name);
    }
}
