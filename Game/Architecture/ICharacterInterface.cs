using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface ICharacterInterface : IEntityInterface
    {
        public int Health { get; set; }
        public int Speed { get; }
        public int JumpHeight { get; }
        public Weapon Weapon { get; set; }
        public void Action();
        public void OnDeath();
    }
}
