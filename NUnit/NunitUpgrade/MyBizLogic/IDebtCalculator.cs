namespace MyBizLogic
{
    public interface IDebtCalculator
    {
        string BatchProcessing(string sourcePath, string targetPath);
        double ByMethod(CalculatorMethod method);
    }
}