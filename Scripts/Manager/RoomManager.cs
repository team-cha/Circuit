using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance = null;

    private GameObject player;
    private GameObject character;

    public GameObject[] rooms;
    public GameObject loading;

    private int step = 0;
    public int Step
    {
        get { return step; }
        set
        {
            step = value;

            if (step < rooms.Length)
            {
                NextStep(step);
            }
            else
            {
                MySceneManager.instance.MyLoadScene("Map");
            }
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        player = GameObject.Find("Player");
        character = GameObject.Find("Character");
    }

    void Start()
    {
        step = 0;
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].SetActive(false);
        }
        rooms[step].SetActive(true);
    }

    public void NextStep(int step)
    {
        StartCoroutine(RoomLoading(step));
    }

    private IEnumerator RoomLoading(int step)
    {
        // 로딩 스크린 호출
        LoadingManager.instance.Loading("Next step (" + step + " / " + rooms.Length + ")");
        rooms[step - 1].SetActive(false);

        // 플레이어 미사일 비활성화
        character.SetActive(false);

        // 로딩 시간이 계산 안 된 경우 대기
        while (LoadingManager.instance.loadingTime == 0)
        {
            yield return null;
        }
        yield return new WaitForSeconds(LoadingManager.instance.loadingTime);

        // 플레이어 위치 세팅 수정 중
        player.transform.position = Vector3.zero;
        character.transform.rotation = Quaternion.Euler(Vector3.zero);
        
        // 플레이어 미사일 활성화
        character.SetActive(true);
        rooms[step].SetActive(true);
    }
}
