using System;
using System.Collections.Generic;
namespace SedaCinar.AreaFinder.Model
{
    [Serializable]
    public class MapContent
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<ElementContent> Elements { get; set; }
   
        public MapContent() 
        {
            Elements = new List<ElementContent>();
        }
    }
}