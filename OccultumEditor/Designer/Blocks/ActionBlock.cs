using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OccultumEditor.Designer.Blocks
{
    //the block that can be placed to dictate the flow of the scene
    abstract class ActionBlock
    {
        private int ID;

        /**
         * this method will be called to write its signature into the file
         */
        public abstract void encode();
    }
}
