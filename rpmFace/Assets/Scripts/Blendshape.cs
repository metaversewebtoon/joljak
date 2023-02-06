/// <summary>
/// Wrapper Class for Positive & Negative Values of Blendshapes
/// </summary>
namespace ywe.Blendshapes
{
    public class Blendshape
    {
        public int positiveIndex { get; set; }
        //public int negativeIndex { get; set; }

        //public Blendshape(int positiveIndex, int negativeIndex)
        public Blendshape(int positiveIndex)
        {
            this.positiveIndex = positiveIndex;
            //this.negativeIndex = negativeIndex;
        }

    } 
}
