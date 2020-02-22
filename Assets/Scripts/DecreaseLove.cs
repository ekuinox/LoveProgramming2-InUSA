using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DecreaseLoveEvent : LoveEvent
{
    int count = 0;
    int target = 0;
    public void init(Dictionary<string, string> args)
    {
        var count = "0";
        args.TryGetValue("count", out count);
        this.count = int.Parse(count);

        var target = "0";
        args.TryGetValue("target", out target);
        this.target = int.Parse(target);
    }

    public void run(MessageText messageText)
    {
        switch (target)
        {
            case 0:
                Manager.unityLovePoint -= count;
                UnityEngine.Debug.Log($"unityの好感度{count} 減らしちゃるぞ");
                break;
            case 1:
                Manager.ue4LovePoint -= count;
                UnityEngine.Debug.Log($"ue4の好感度{count} 減らしちゃるぞ");
                break;
            default:
                break;
        }
    }

}
