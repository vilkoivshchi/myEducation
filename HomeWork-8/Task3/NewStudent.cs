using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task3
{
    public class NewStudent
    {
        private string fileName;
        private List<Students> list;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public Students this[int index]
        {
            get { return list[index]; }
        }

        public NewStudent(string fileName)
        {
            this.fileName = fileName;
            list = new List<Students>();
        }

        public int Count
        {
            get { return list.Count; }
        }
        
        public void LoadCSV()
        {
            using(StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    byte course, age;
                    string[] line = reader.ReadLine().Split(';');
                    if (byte.TryParse(line[2], out course) && byte.TryParse(line[3], out age))
                    {
                        list.Add(new Students(line[1], line[0], course, age));
                    }
                    
                }
            }
        }

        

        public void SaveAs(string fileNameSaveAs)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Students>));
            using (FileStream fileStream = new FileStream(fileNameSaveAs, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, list);
            }
            
        }


    }
}
