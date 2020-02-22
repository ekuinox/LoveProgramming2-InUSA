using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ESceneState
{
    eTitle,
    eSanFrancisco,
    eLosAngeles,
    eGalGame
}

static public class SceneController
{

    /*------------------------------------------
     * LoadScene  : シーンの読み込み
     * state      : 読み込むシーンステート
     -------------------------------------------*/
    static public void LoadScene(ESceneState state)
    {
        int index = GetSceneIndex(state);
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    /*------------------------------------------
     * AttachScene  : シーンのアタッチ
     * state        : アタッチするシーンステート
     -------------------------------------------*/
    static public void AttachScene(ESceneState state)
    {
        int index = GetSceneIndex(state);
        SceneManager.LoadScene(index, LoadSceneMode.Additive);
    }

    /*------------------------------------------
     * GetSceneIndex  : シーンの番号を取得
     * state          : 取得したいシーンのステート
     * 戻り値         : シーンの番号
     -------------------------------------------*/
    static private int GetSceneIndex(ESceneState state)
    {
        switch (state)
        {
            case ESceneState.eTitle:
                return 0;

            case ESceneState.eSanFrancisco:
                return 1;

            case ESceneState.eLosAngeles:
                return 2;

            case ESceneState.eGalGame:
                return 3;

            default:
                return -1;
        }
    }
}
