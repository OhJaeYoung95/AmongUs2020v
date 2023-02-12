using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewFloater : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;      // 크루원 프리팹
    [SerializeField]
    private List<Sprite> sprites;   // 크루원 이미지 변경 스프라이트

    private bool[] crewStates = new bool[12];   // 크루원 색상 상태(겹치지 않게 하기 위함)
    private float timer = 0.5f;     // 프리팹 생성 간격 주기
    private float distance = 11f;   // 프리팹 생성 위치

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            SpawnFloatingCrew((EPlayerColor)i, Random.Range(0, distance));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 시간에 따라서 떠다니는 크루원 생성
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            SpawnFloatingCrew((EPlayerColor)Random.Range(0, 12), distance);
            timer = 1f;
        }
    }

    // 떠다니는 크루원 생성
    public void SpawnFloatingCrew(EPlayerColor playerColor, float dist)
    {
        if(!crewStates[(int)playerColor])   // 크루원 색상 중복 확인
        {
            crewStates[(int)playerColor] = true;

            float angle = Random.Range(0, 360f);
            Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f) * dist;  // 중심으로부터 원형의 방향을 돌아가며 가리키는 백터 방향 구할 수 있음
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            float floatingSpeed = Random.Range(1f, 4f);
            float rotateSpeed = Random.Range(-3f, 3f);

            // 크루원 생성 및 해당 크루원 랜덤 설정
            var crew = Instantiate(prefab, spawnPos, Quaternion.identity).GetComponent<FloatingCrew>();
            crew.SetFloatingCrew(sprites[Random.Range(0, sprites.Count)], playerColor, 
                direction, floatingSpeed, rotateSpeed, Random.Range(0.5f, 1f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 크루원이 영역 밖을 나갈때 제거, 색상 재사용하기 위한 값 설정
        var crew = collision.GetComponent<FloatingCrew>();
        if(crew != null)
        {
            crewStates[(int)crew.playerColor] = false;
            Destroy(crew.gameObject);
        }
    }
}
