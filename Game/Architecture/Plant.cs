using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game {
    public enum PlantsType {
        firstBush,
        secondBush,
        firstTree,
        secondTree,
        fir,
    }
    public class Plant : StaticObject {
        private Dictionary<PlantsType, string> plantsType = new Dictionary<PlantsType, string>() {
            {PlantsType.firstBush, "firstBush.png"},
            {PlantsType.secondBush, "secondBush.png"},
            {PlantsType.firstTree, "firstTree.png"},
            {PlantsType.secondTree, "secondTree.png"},
            {PlantsType.fir, "thirdTree.png"},
        };
        public Plant(Point location, Size size, PlantsType plantType)
            :base( size, location){
            Tag = "plant";
            Image = new Bitmap(PathToImages + plantsType[plantType]);
        }
    }
}