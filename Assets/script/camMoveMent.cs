using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMoveMent : MonoBehaviour
{
    public static camMoveMent Instance;
    [SerializeField]
    Transform playerPos;
    [SerializeField]
    public Vector3 camlocalPos;
    public float followSpeed = 2f;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (playerPos!=null)
        {
            Vector3 tmp = transform.position - camlocalPos;
            tmp = Vector3.Lerp(tmp, playerPos.position, Time.deltaTime * followSpeed);
            transform.position = tmp + camlocalPos;
        }
    }
    public void Get_Player_Position(Transform player)
    {//플레이어가 생성될 때 사용
        playerPos = player;
        transform.position = playerPos.position;
    }
    public void Clear_Player_Position()
    {//씬로더가 필요한 씬 로드전에 사용
        playerPos = null;
        transform.position = camlocalPos;
    }
}
/*
public class camMoveMent : MonoBehaviour
{
    public Transform playerPos;
    public float followSpeed = 1f;
    public Vector3 camlocalPos;
    void Update()
    {
        Vector3 tmp = transform.position - camlocalPos;
        tmp = Vector3.Lerp(tmp,playerPos.position,Time.deltaTime * followSpeed);
        transform.position = tmp + camlocalPos;
    }
}
 */