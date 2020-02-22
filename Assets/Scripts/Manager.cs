using UnityEngine;

public static class Manager
{
    private static bool isLoaded = false;

    // 経過日数
    private static uint passedDays = 1;

    public static Message[] messages;

    public static int unityLovePoint = 0;

    public static int ue4LovePoint = 0;

    public static void Load(bool isForce = false)
    {
        if (!isLoaded || isForce)
        {
            messages = MessageLoader.GetFromFile($"{Application.dataPath}/messages.json").ToArray();
            EventLoader.GetFromFile($"{Application.dataPath}/events.json");
            isLoaded = true;
        }
    }

    /// <summary>
    /// 日を一日すすめる
    /// </summary>
    /// <returns>
    /// 進めたあとの値が返る
    /// </returns>
    public static uint ForwardDay()
    {
        passedDays += 1;
        Debug.Log($"{passedDays}日目になりました");
        return passedDays;
    }

    /// <summary>
    /// 今日何日目？
    /// </summary>
    /// <returns></returns>
    public static uint GetPassedDay()
    {
        return passedDays;
    }

    public static void FirstDay()
    {
        passedDays = 1;
    }
}