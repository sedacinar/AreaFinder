using UnityEngine;
using SedaCinar.AreaFinder.Interface;
using SedaCinar.AreaFinder.Model;

namespace SedaCinar.AreaFinder.Core
{
    public class MapCreator : MonoBehaviour, MapInterface
    {
        #region Variables
        MapContent mapContent;
        #endregion
        #region Public Methods
        public void AddElement(ElementContent elementContent)
        {
            if(elementContent == null)
            {
                return;
            }
            if(mapContent == null) 
            {
                mapContent = new MapContent();
            }
            mapContent.Elements.Add(elementContent);
        }
        public void SetContent(MapContent mapContent)
        {
            if(mapContent == null) 
            {
                return;
            }
            this.mapContent = mapContent;
        }
        public void GetContent(out MapContent mapContent)
        {
            mapContent = this.mapContent;
        }
        public void ResetContent()
        {
            mapContent = new MapContent();
        }
        #endregion
        #region Interface Methods
        public void ClearBorder(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public void GetSize(out int width, out int height)
        {
            width = this.mapContent.Width;
            height = this.mapContent.Height;
        }

        public bool IsBorder(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public void SetBorder(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public void SetSize(in int width, in int height)
        {
            this.mapContent.Width = width;
            this.mapContent.Height = height;
        }

        public void Show()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
