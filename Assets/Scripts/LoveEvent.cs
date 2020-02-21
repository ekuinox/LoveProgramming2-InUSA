using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface LoveEvent
{
    void init(Dictionary<string, string> args);
    void run();
}
