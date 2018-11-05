namespace PiyiServer.Server
{
    public class StaticData
    {
        private static StaticData _current;
        public static StaticData Current => _current ?? (_current = new StaticData());

        private StaticData() { }

        public string Sentence { get; set; }
    }
}
