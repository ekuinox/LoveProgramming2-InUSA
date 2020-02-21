using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DecreaseLoveEvent : LoveEvent
{
    int count = 0;
    public void init(Dictionary<string, string> args)
    {
        var count = "0";
        args.TryGetValue("count", out count);
        this.count = int.Parse(count);
    }

    public void run()
    {
        UnityEngine.Debug.Log($"{count} 減らしちゃるぞ");
    }

}
