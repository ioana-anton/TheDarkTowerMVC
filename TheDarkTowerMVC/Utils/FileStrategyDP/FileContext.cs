namespace TheDarkTowerMVC.Utils.FileStrategyDP
{
    public class FileContext
    {
        private FileStrategy _fileStrategy;

        public FileContext(FileStrategy fileStrategy)
        {
            _fileStrategy = fileStrategy;
        }

        public void CreateFile(String input)
        {
            if (_fileStrategy != null)
                _fileStrategy.CreateFile(input);
        }
    }
}
