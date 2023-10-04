using System.Collections.Generic;

namespace Game
{
    public struct CuttingResult
    {
        public float Angel { get; private set; }
        public CuttedObject CuttedObject { get; private set; }
        public List<CuttedPieces> CuttedPieces { get; private set; }

        public CuttingResult (float angel, CuttedObject cuttedObject, List<CuttedPieces> cuttedPieces)
        {
            Angel = angel;
            CuttedObject = cuttedObject;
            CuttedPieces = new List<CuttedPieces>(cuttedPieces);
        }
    }
}