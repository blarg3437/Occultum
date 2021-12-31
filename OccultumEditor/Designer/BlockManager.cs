using OccultumEditor.Designer.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OccultumEditor.Designer
{
    class BlockManager
    {
        List<ActionBlock> blocks;

        public void addBlock(ActionBlock b)
        {
            if (b != null)
                blocks.Add(b);
        }

        //public ActionBlock addBlock(string type)
        //{
        //    switch(type)
        //    {
        //        case "walk":
        //            break;

        //        case "spawn":
        //            break;

        //        case "delete":
        //            break;

        //        case "turnleft":
        //            break;
                    
        //        case "turnright":
        //            break;

        //        default:
        //            return null;
        //            break;
        //    }
        //}
    }


}
