using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task3
{
    public class TrueFalse
    {
        private string fileName;
        private List<Question> list;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public Question this[int index]
        {
            get { return list[index]; }
        }

        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        public int Count
        {
            get { return list.Count; }
        }

        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0)
                list.RemoveAt(index);
        }
        /*
        public void Load()
        {
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
             
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                list = (xmlSerializer.Deserialize((fileStream)) as List<Question>);
            }
            
            
        }
        */
        public void LoadCSV()
        {
            using(StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(';');
                }
            }
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, list);
            }
        }
        public void SaveAs(string fileNameSaveAs)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (FileStream fileStream = new FileStream(fileNameSaveAs, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, list);
            }
        }


    }
}
