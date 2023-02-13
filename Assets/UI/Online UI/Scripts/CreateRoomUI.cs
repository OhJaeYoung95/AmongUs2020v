using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField]
    private List<Image> crewImgs;

    [SerializeField]
    private List<Button> imposterCountButtons;

    [SerializeField]
    private List<Button> maxPlayerCountButtons;

    private CreateGameRoomData roomData;

    // Start is called before the first frame update
    void Start()
    {
        // Materail 인스턴스화, 룸 데이터 설정
        for (int i = 0; i < crewImgs.Count; i++)
        {
            Material materialInstance = Instantiate(crewImgs[i].material);
            crewImgs[i].material = materialInstance;
        }
        roomData = new CreateGameRoomData() { imposterCount = 1, maxPlayerCount = 10 };
        UpdateCrewImages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 최대인원수 수 업데이트, 최대 인원수 버튼클릭
    public void UpdateMaxPlayerCount(int count)
    {
        roomData.maxPlayerCount = count;

        // 해당 버튼이미지의 알파값 설정
        for (int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            // 해당하는 버튼이면 알파값 1 / 보이게 설정
            if(i == count - 4)
            {
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else    // 해당하지 않는 버튼이면 알파값 0 / 안보이게 설정
            {
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        UpdateCrewImages();
    }

    // 임포스터 인원 수 업데이트, 임포스터 인원수 버튼클릭
    public void UpdateImposterCount(int count)
    {
        roomData.imposterCount = count;

        for (int i = 0; i < imposterCountButtons.Count; i++)
        {
            // 해당하는 버튼이면 알파 값 1 / 보이게 설정
            if (i == count - 1)
            {
                imposterCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else         // 해당하지 않는 버튼이면 알파 값 0 / 안보이게 설정
            {
                imposterCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        // 임포스터 수에 따른 최대인원 수
        int limitMaxPlayer = count == 1 ? 4 : count == 2 ? 7 : 9;

        if(roomData.maxPlayerCount < limitMaxPlayer)
        {
            // 제한인원수에 맞는 최대인원수 설정
            UpdateMaxPlayerCount(limitMaxPlayer);
        }
        else
        {
            UpdateMaxPlayerCount(roomData.maxPlayerCount);
        }

        // 임포스터 수에 따라서 최대 인원수 제한
        for (int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            var text = maxPlayerCountButtons[i].GetComponentInChildren<Text>();
            // 임포스터수 : 최대인원수 => 1/2/3 : 4/7/9
            if(i < limitMaxPlayer - 4)
            {
                // 버튼 상호작용 불가능, 텍스트색(회색)
                maxPlayerCountButtons[i].interactable = false;
                text.color = Color.gray;
            }
            else
            {
                // 버튼 상호작용 가능, 텍스트색(흰색)
                maxPlayerCountButtons[i].interactable = true;
                text.color = Color.white;
            }
        }
    }

    // 크루원 이미지 업데이트
    private void UpdateCrewImages()
    {
        // 초기 크루원 색 설정(흰색)
        for (int i = 0; i < crewImgs.Count; i++)
        {
            crewImgs[i].material.SetColor("_PlayerColor", Color.white);
        }

        int imposterCount = roomData.imposterCount;
        int idx = 0;
        // 크루원 0 ~ maxPlayer수 만큼 돌면서 랜덤으로 임포스터 지정
        while(imposterCount != 0)
        {
            if(idx >= roomData.maxPlayerCount)
            {
                idx = 0;
            }

            if(crewImgs[idx].material.GetColor("_PlayerColor") != Color.red && Random.Range(0, 5) == 0)
            {
                crewImgs[idx].material.SetColor("_PlayerColor", Color.red);
                imposterCount--;
            }
            idx++;
        }

        // maxPlayer수만큼 크루원 이미지 활성화
        for (int i = 0; i < crewImgs.Count; i++)
        {
            if(i < roomData.maxPlayerCount)
            {
                crewImgs[i].gameObject.SetActive(true);
            }
            else
            {
                crewImgs[i].gameObject.SetActive(false);
            }
        }
    }
}

// 게임룸 데이터
public class CreateGameRoomData
{
    public int imposterCount;
    public int maxPlayerCount;
}
