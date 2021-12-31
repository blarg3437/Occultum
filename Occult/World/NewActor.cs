using Occult.World.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.World
{
    /**
     * Component model
     */
    public class NewActor
    {
        static private int currentID;
        
        private int Id;
        
        List<IComponent> componets;

        public NewActor()
        {
            Id = ++currentID;//this could present some problems later on as this number grows large
            //or the game restarts and new entities are added in and it isnt checked, causing duplicate id's
        }

        public void addComponent(IComponent newComponent)
        {
            if (componets.Contains(newComponent)) return;
            componets.Add(newComponent);

        }
    }
}
