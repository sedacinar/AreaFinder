using UnityEngine;
using UnityEngine.UI;
using SedaCinar.AreaFinder.Model;

namespace SedaCinar.AreaFinder.Core
{
    public class MapElement : MonoBehaviour
    {
        #region Fields
        Image image;
        MouseInput mouseInput;
        ElementContent elementContent;
        RectTransform rectTransform;
        #endregion
        #region Unity Methods
        private void Update()
        {
            if(IsBorder() || !mouseInput.IsPressed)
            {
                return;
            }
           
            if(RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
            {
                SetBorder();
            }
        }
        #endregion
        #region Public Methods
        public void Initialize()
        {
            image = GetComponent<Image>();
            rectTransform = GetComponent<RectTransform>();
            mouseInput = FindObjectOfType<MouseInput>();
            elementContent = new ElementContent();
        }
        public ElementContent GetContent()
        {
            return elementContent;
        }
        public void GetLocation(out int width, out int height)
        {
            width = elementContent.Row;
            height = elementContent.Column;
        }
        public void SetLocation(in int column, in int row)
        {
            this.elementContent.Column = column;
            this.elementContent.Row = row;
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