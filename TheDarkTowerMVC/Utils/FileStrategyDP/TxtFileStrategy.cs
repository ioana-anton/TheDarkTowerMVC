using System.Text;

namespace TheDarkTowerMVC.Utils.FileStrategyDP
{
    public class TxtFileStrategy : FileStrategy
    {
        public override void CreateFile(string input)
        {
            string fileName = @"D:\Windows F\VisualStudio\TheDarkTowerMVC - test\TheDarkTowerMVC\GeneratedTextFile.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file    
                    // Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    Byte[] bytes = new UTF8Encoding(true).GetBytes(input);
                    fs.Write(bytes, 0, bytes.Length);
                    //byte[] author = new UTF8Encoding(true).GetBytes("Mahesh Chand");
                    //fs.Write(author, 0, author.Length);
                }

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
