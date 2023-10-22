using System.Collections.Generic;
using System.Linq;

public class AllPopedRool : IRool
{
    public bool Check(IList<Ball> balls) => balls.All(t => t.IsPoped);
}