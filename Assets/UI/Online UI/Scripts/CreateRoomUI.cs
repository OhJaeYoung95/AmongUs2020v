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
        // Materail �ν��Ͻ�ȭ, �� ������ ����
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

    // �ִ��ο��� �� ������Ʈ, �ִ� �ο��� ��ưŬ��
    public void UpdateMaxPlayerCount(int count)
    {
        roomData.maxPlayerCount = count;

        // �ش� ��ư�̹����� ���İ� ����
        for (int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            // �ش��ϴ� ��ư�̸� ���İ� 1 / ���̰� ����
            if(i == count - 4)
            {
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else    // �ش����� �ʴ� ��ư�̸� ���İ� 0 / �Ⱥ��̰� ����
            {
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        UpdateCrewImages();
    }

    // �������� �ο� �� ������Ʈ, �������� �ο��� ��ưŬ��
    public void UpdateImposterCount(int count)
    {
        roomData.imposterCount = count;

        for (int i = 0; i < imposterCountButtons.Count; i++)
        {
            // �ش��ϴ� ��ư�̸� ���� �� 1 / ���̰� ����
            if (i == count - 1)
            {
                imposterCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else         // �ش����� �ʴ� ��ư�̸� ���� �� 0 / �Ⱥ��̰� ����
            {
                imposterCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        // �������� ���� ���� �ִ��ο� ��
        int limitMaxPlayer = count == 1 ? 4 : count == 2 ? 7 : 9;

        if(roomData.maxPlayerCount < limitMaxPlayer)
        {
            // �����ο����� �´� �ִ��ο��� ����
            UpdateMaxPlayerCount(limitMaxPlayer);
        }
        else
        {
            UpdateMaxPlayerCount(roomData.maxPlayerCount);
        }

        // �������� ���� ���� �ִ� �ο��� ����
        for (int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            var text = maxPlayerCountButtons[i].GetComponentInChildren<Text>();
            // �������ͼ� : �ִ��ο��� => 1/2/3 : 4/7/9
            if(i < limitMaxPlayer - 4)
            {
                // ��ư ��ȣ�ۿ� �Ұ���, �ؽ�Ʈ��(ȸ��)
                maxPlayerCountButtons[i].interactable = false;
                text.color = Color.gray;
            }
            else
            {
                // ��ư ��ȣ�ۿ� ����, �ؽ�Ʈ��(���)
                maxPlayerCountButtons[i].interactable = true;
                text.color = Color.white;
            }
        }
    }

    // ũ��� �̹��� ������Ʈ
    private void UpdateCrewImages()
    {
        // �ʱ� ũ��� �� ����(���)
        for (int i = 0; i < crewImgs.Count; i++)
        {
            crewImgs[i].material.SetColor("_PlayerColor", Color.white);
        }

        int imposterCount = roomData.imposterCount;
        int idx = 0;
        // ũ��� 0 ~ maxPlayer�� ��ŭ ���鼭 �������� �������� ����
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

        // maxPlayer����ŭ ũ��� �̹��� Ȱ��ȭ
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

// ���ӷ� ������
public class CreateGameRoomData
{
    public int imposterCount;
    public int maxPlayerCount;
}
