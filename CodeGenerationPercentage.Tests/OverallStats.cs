namespace CodeGenerationPercentage.Tests
{
    public class OverallStats
    {
        public long totalLines { get; set; }

        public long generatedLines { get; set; }

        public long handWrittenLines { get; set; }

        public long totalFiles { get; set; }

        public long totalGeneratedFiles { get; set; }

        public long totalhandWrittenFiles { get; set; }

        public double PercentageGeneratedLines()
        {
            return 100.0 / this.totalLines * this.generatedLines;
        }

        public double PercentageGeneratedFiles()
        {
            return 100.0 / this.totalFiles * this.totalGeneratedFiles;
        }
    }
}