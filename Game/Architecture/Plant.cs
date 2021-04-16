using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game {
    public enum PlantsType {
        firstBush,
        secodBush,
        firstTree,
        secondTree,
        fir,
    }
    public class Plant : PictureBox {
        private Dictionary<PlantsType, string> plantsType = new Dictionary<PlantsType, string>() {
            {PlantsType.firstBush, "firstBush.png"},
            {PlantsType.secodBush, "secodBush.png"},
            {PlantsType.firstTree, "firstTree.png"},
            {PlantsType.secondTree, "secondTree.png"},
            {PlantsType.fir, "thirdTree.png"},
        };
        public Plant(Point location, Size size, PlantsType plantType){
            Location = location;
            Size = size;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Tag = "plant";
            Image = new Bitmap(PathToImages + plantsType[plantType]);
            Visible = true;
        }
        protected string PathToImages = GetGameDirectoryRoot().FullName.ToString() + "\\Images\\";
        private static DirectoryInfo GetGameDirectoryRoot() {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (!dir.ToString().EndsWith("GameOfTheCentury")) {
                dir = dir.Parent;
            }

            return dir;
        }
    }
}