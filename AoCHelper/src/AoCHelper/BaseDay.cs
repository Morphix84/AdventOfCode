namespace AoCHelper
{
    /// <summary>
    /// <see cref="BaseProblem  "/> with custom <see cref="BaseProblem.ClassPrefix"/> ("Day") and <see cref="BaseProblem.InputFileExtension"/> (".txt")
    /// </summary>
    public abstract class BaseDay : BaseProblem
    {
        protected readonly string _input;
        protected bool inputValid = false;
        protected BaseDay()
        {
            if(File.Exists(InputFilePath))
            { 
                _input = File.ReadAllText(InputFilePath);
                inputValid = true;
            }
            else
            {
                var task = AdventOfCodeService.FetchInput(CalculateYear(), CalculateIndex());
                try
                {
                    task.Wait();
                }
                catch (InvalidOperationException)
                {
                    return;
                }
                
                _input = task.Result;
                File.WriteAllText(InputFilePath, _input);
                inputValid = true;
            }

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override string ClassPrefix { get; } = "Day";
    }
}
