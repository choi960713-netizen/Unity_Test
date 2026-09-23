using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    //싱글톤 인스턴스
    public static ObjectPoolManager instance { get; private set; }

    [System.Serializable]
    public class Pool
    {
        public string key;      //풀 이름(파이어볼, 총알, 에너미)
        public GameObject prefab;       //생성할 프리펩
        public int size;        //미리 생성할 게임오브젝트 겟수
    }

    [SerializeField] List<Pool> pools;  //인스펙터에서 설정할 풀 목록

    //풀의 이름을 키값으로 큐를 찾기 위해서
    Dictionary<string,Queue>

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy (gameObject);
            return;
        }
        //딕셔너리 초기화
        poolDictionary = new Dictionary<string,Queue>
    }
}
