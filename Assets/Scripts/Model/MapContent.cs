using System;
using SedaCinar.AreaFinder.Core;
using System.Collections.Generic;
namespace SedaCinar.AreaFinder.Model
{
    [Serializable]
    public class MapContent
    {
        public int Width;
        public int Height;
        public List<ElementContent> Elements;
   
        public MapContent() 
        {
            Elements = new List<ElementContent>();
        }
    }
}