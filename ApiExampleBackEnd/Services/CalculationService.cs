using ApiExampleBackEnd.Models;

namespace ApiExampleBackEnd.Services
{
    public static class CalculationService
    {
        public static CalculationsResult Calculate(int number1, int number2)
        {
            var result = new CalculationsResult();
            result.AdditionResult = number1 + number2;
            result.SubtractionResult = number1 - number2;
            result.DivsionResult = number1 / number2;
            result.MultiplicationResult = number1 * number2;
            return result;
        }
    }
}