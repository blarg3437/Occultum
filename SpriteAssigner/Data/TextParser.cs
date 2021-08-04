using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteAssigner.Data
{
    /**
     * to utilize this class, make a reference, then call begin for reading OR writing, do the task, then call end
     */
    class TextParser
    {
        string location;
        char delimeter;
        StreamReader reader;
        StreamWriter writer;
        bool reading;
        bool writing;
        public TextParser(string location, char delimeter = '=')
        {
            this.location = location;
        }

        public void Begin(bool read)
        {
            if(read)
            {
                reading = true;
                reader = new StreamReader(location);
            }
            else
            {
                writing = true;
                writer = new StreamWriter(location);
            }
        }

        public void End(bool read)
        {
            if (read)
            {
                reading = false;
                reader.Close();
            }
            else
            {
                writing = false;
                writer.Close();
            }
        }

        /**
         * File should consist of lines as such,
         * parameter=#
         * 
         * returns int.minvalue if it cannot find it
         */
        public int retreiveInteger(string parameter)
        {
            string line;
            while((line = reader.ReadLine()) != null)
            {
                if(line.Contains(parameter))
                {
                    int value;
                    string[] pieces = line.Split('=');
                    value = int.Parse(pieces[1]);
                    return value;
                }
            }
            return int.MinValue;
        }

        public bool writeInteger(string paremeter, int value)
        {
            return false;
            //in the future write something here that reads in the entire file, and edits parts
            //it might be better to have a consume function, that way I can read in once and then write once
        }



    }
}
