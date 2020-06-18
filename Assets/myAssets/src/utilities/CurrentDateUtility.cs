using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

class CurrentDateUtility
{
    public static string GetCurrentDate()
    {
        return System.DateTime.UtcNow.ToString(CultureInfo.CreateSpecificCulture("en-US"));
    }
}
