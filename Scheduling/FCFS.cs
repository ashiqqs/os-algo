using static System.Console;

namespace OsAlgo.Scheduling
{
    public class FCFS
    {
        //Experimenting First Come First Serve Scheduling
        public static void Calculate()
        {
            int[] burst_time, turnAroundTime, waitingTime;
            int i, totalWTime=0, totalBtime=0, totalTtime=0;
            float avgWtime = 0, avgTtime = 0;
            Write("Enter the number of process: ");
            int numberOfProcess = int.Parse(ReadLine());
            burst_time = new int[numberOfProcess];
            turnAroundTime = new int[numberOfProcess];
            waitingTime = new int[numberOfProcess];

            //Taking input
            for (i=0; i<numberOfProcess; i++)
            {
                Write($"P-{i + 1} burst time: ");
                burst_time[i] = int.Parse(ReadLine());
            }
            
            //Finding turnaround and waiting time
            for (i=0; i< numberOfProcess; i++)
            {
                totalBtime += burst_time[i];
                turnAroundTime[i] = totalBtime;
                totalTtime += turnAroundTime[i];
                waitingTime[i] = turnAroundTime[i] - burst_time[i];
                totalWTime += waitingTime[i];
            }
            avgWtime = (float)totalWTime / numberOfProcess;
            avgTtime = (float)totalTtime / numberOfProcess;

            //Printing result
            WriteLine("Process Burst Waiting Turnaround");
            for (i = 0; i < numberOfProcess; i++){
                WriteLine($"P-{i + 1} \t {burst_time[i]} \t {waitingTime[i]} \t {turnAroundTime[i]}");
            }
            WriteLine();
            WriteLine($"Average waiting time {avgWtime}");
            WriteLine($"Average turnaround time {avgTtime}");
        }
    }
}
