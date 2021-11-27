using static System.Console;

namespace OsAlgo.Scheduling
{
    public class SJF
    {
        static Process[] process;

        public static void Calculate()
        {
            int i, j, totalBurst = 0, totalTtime = 0, totalWtime = 0 ;
            float avgWtime = 0, avgTtime = 0;
            Write("Enter the number of process: ");
            int numOfProcess = int.Parse(ReadLine());
            process = new Process[numOfProcess];

            //Taking input process burst time
            for(i = 0; i < numOfProcess; i++)
            {
                process[i].PID = i + 1;
                Write($"P-{i + 1} burst time: ");
                process[i].Burst = int.Parse(ReadLine());
            }

            //Sort by burst time;
            for(i=0; i<numOfProcess; i++)
            {
                for(j=i+1; j<numOfProcess; j++)
                {
                    if (process[i].Burst > process[j].Burst)
                    {
                        var temp = process[i];
                        process[i] = process[j];
                        process[j] = temp;
                    }
                }
            }

            for(i=0; i<numOfProcess; i++)
            {
                totalBurst += process[i].Burst;
                process[i].Turnaround = totalBurst;
                totalTtime += totalBurst;

                process[i].Waiting = process[i].Turnaround - process[i].Burst;
                totalWtime += process[i].Waiting;
            }

            avgWtime = (float)totalWtime / numOfProcess;
            avgTtime = (float)totalTtime / numOfProcess;

            WriteLine("Process Burst Waiting Turnaround");
            for (i = 0; i < numOfProcess; i++)
            {
                WriteLine($"P-{process[i].PID} \t {process[i].Burst} \t {process[i].Waiting} \t {process[i].Turnaround}");
            }
            WriteLine();
            WriteLine($"Average waiting time {avgWtime}");
            WriteLine($"Average turnaround time {avgTtime}");

        }
    }

    struct Process
    {
        public int PID;
        public int Burst;
        public int Waiting;
        public int Turnaround;
    }
}
