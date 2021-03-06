﻿using System;

namespace PKHeX.Core
{
    /// <summary>
    /// Generation 2 Time of Encounter enum
    /// </summary>
    [Flags]
    internal enum EncounterTime
    {
        Any = 0,
        Morning = 1 << 1,
        Day = 1 << 2,
        Night = 1 << 3,
    }

    internal static class EncounterTimeExtension
    {
        internal static bool Contains(this EncounterTime t1, int t2) => t1.HasFlag((EncounterTime)(1 << t2));
        internal static int RandomValidTime(this EncounterTime t1)
        {
            int val = Util.Rand.Next(1, 4);
            if (t1 == EncounterTime.Any)
                return val;
            while (!t1.Contains(val))
                val = Util.Rand.Next(1, 4);
            return val;
        }
    }
}