using System;
using System.Collections.Generic;
using System.Linq;

public class OneColorRool : IRool
{
    public bool Check(IList<Ball> balls)
    {
        foreach (BallType type in Enum.GetValues(typeof(BallType)))
        {
            IEnumerable<Ball> list = balls.Where(t => t.Type == type);
            bool result = list.All(t => t.IsPoped);

            if (result) return true;
        }

        return false;
    }
}