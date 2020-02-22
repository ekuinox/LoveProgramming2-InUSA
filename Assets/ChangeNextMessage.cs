using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ChangeNextMessage : LoveEvent
{
    private int nextId = -1;
    public void init(Dictionary<string, string> args)
    {
        var nextId = "-1";
        var result = args.TryGetValue("nextId", out nextId);
        this.nextId = result ? int.Parse(nextId) : -1;
    }

    public void run(MessageText messageText)
    {
        messageText.Next(nextId);
    }
}
