using SedaCinar.AreaFinder.Model;
using UnityEngine;
using UnityEngine.UI;

namespace SedaCinar.AreaFinder.Core
{
    public class MapElement : MonoBehaviour
    {
        #region Fields
        Image image;
        ElementContent elementContent;
        MapCreator mapCreator;
        #endregion
        #region Public Methods
        public void Initialize()
        {
            image = GetComponent<Image>();
            mapCreator = FindObjectOfType<MapCreator>();
            elementContent = new ElementContent();
            mapCreator.AddElement(elementContent);
        }
        public ElementContent GetContent()
        {
            return elementContent;
        }
        public Vector2 GetLocation()
        {
            return new Vector2(elementContent.Row, elementContent.Column);
        }
        public void SetLocation(int column, int row)
        {
            this.elementContent.Row = row;
            this.elementContent.Column = column;
        }
        public void SetBorder()
        {
            elementContent.IsBorder = true;
            image.color = Color.black;
        }
        public void ClearBorder()
        {
            elementContent.IsBorder = false;
            image.color = Color.white; 
        }
        public bool IsBorder()
        {
            return elementContent.IsBorder;
        }
        #endregion

    }
}