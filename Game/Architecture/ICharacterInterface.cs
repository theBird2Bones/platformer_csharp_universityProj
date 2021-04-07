using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface ICharacterInterface : IEntityInterface
    {
        int Health { get; set; }
        int Speed { get; }
        int JumpHeight { get; }
        Weapon Weapon { get; set; }
        void Action();
        void OnDeath();
    }
}
