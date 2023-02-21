using System;

namespace SedaCinar.AreaFinder.Model
{
    [Serializable]
    public class ElementContent
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsBorder { get; set; }
    }
}