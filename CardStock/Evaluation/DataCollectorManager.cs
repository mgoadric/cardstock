namespace CardStock.Evaluation;

public class DataCollectorManager
{
    private readonly Dictionary<string, StreamWriter> dataFiles = [];
    private readonly List<DataCollector> collectors;
    private readonly Experiment exp;
    public DataCollectorManager(Experiment experiment)
    {
        exp = experiment;
        collectors = new List<DataCollector>(experiment.NumGames);

        for (int i = 0; i < experiment.NumGames; i++)
        {
            collectors.Add(new DataCollector(experiment, i));
        }
    }

    public void Write()
    {
        string ai = exp.PlayerAbv();
        string path = string.Join("/", ["output", exp.Game, exp.PlayerCount, ai]) + "/";
        List<String> fileStrings = ["lead", "choice", "results", "spread"];

        foreach (string f in fileStrings)
        {
            dataFiles[f] = new(path + f + ".csv");
        }

        foreach (var collector in collectors)
        {
            collector.RecordGameStatistics(dataFiles);
        }

        foreach (StreamWriter file in dataFiles.Values)
        {
            file.Close();
        }
    }

    public DataCollector GetCollector(int index)
    {
        return collectors[index];
    }
}