using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface LoveEvent
{
    public void init(Dictionary<string, string> args);
    public void run();
}
