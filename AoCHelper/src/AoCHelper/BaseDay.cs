namespace AoCHelper
{
    /// <summary>
    /// <see cref="BaseProblem  "/> with custom <see cref="BaseProblem.ClassPrefix"/> ("Day") and <see cref="BaseProblem.InputFileExtension"/> (".txt")
    /// </summary>
    public abstract class BaseDay : BaseProblem
    {
        protected readonly string[] _input;
        protected bool inputValid = false;
        protected BaseDay()
        {
            _input = new string[1];
            if(File.Exists(InputFilePath))
            { 
                _input = File.ReadLines(InputFilePath).ToArray();
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

                var file = File.Create(InputFilePath);
                file.Close();
                File.WriteAllText(InputFilePath, task.Result);
                _input = File.ReadLines(InputFilePath).ToArray();
                inputValid = true;
            }

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override string ClassPrefix { get; } = "Day";
    }
}
