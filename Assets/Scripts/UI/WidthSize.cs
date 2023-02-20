namespace SedaCinar.AreaFinder.UI
{
    public class WidthSize : SizeFieldBase
    {
        #region Base Methods
        protected override void GetInput(string input)
        {
            base.GetInput(input);
            if (string.IsNullOrEmpty(input))
            {
                return;
            }
            int fieldValue = int.Parse(input);
            mapCreator.SetSize(in fieldValue, in height);
        }
        #endregion
    }
}
