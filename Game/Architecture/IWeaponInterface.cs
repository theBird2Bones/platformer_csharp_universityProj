using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game
{
    interface IWeaponInterface
    {
        int BulletCount { get; set; }
        int ReloadingTime { get; set; }
        double SplashRadius { get; set; }
        Vector BulletSpeed { get; set; }
        Vector BulletGravity { get; set; }
        Vector GetTotalBulletVector();
    }
}
