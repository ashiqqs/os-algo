using static System.Console;

namespace OsAlgo.Scheduling
{
    public class RR
    {
        public static void Calculate()
        {
            Process[] process, completedProcess;
            int numOfProcess, quantum, totalWtime=0, totalBtime=0, totalTtime=0,i, j;
            float avgWtime = 0, avgTtime = 0;

            //taking input
            Write("Enter the number of process: ");
            numOfProcess = int.Parse(ReadLine());

            process = new Process[numOfProcess];
            completedProcess = new Process[numOfProcess];
            for (i = 0; i < numOfProcess; i++)
            {
                Write($"P-{i + 1} burst time: ");
                process[i].Burst = int.Parse(ReadLine());
            }
            WriteLine();
            Write("Enter time quantum: ");
            quantum = int.Parse(ReadLine());
            
            //Finding turnaround and waiting time
            int countCompleted = 0;
            while (countCompleted < numOfProcess)
            {
                countCompleted = 0;
                for(i=0; i<numOfProcess; i++)
                {
                    if (process[i].Burst > 0)
                    {
                        if (process[i].Burst < quantum)
                        {
                            totalBtime += process[i].Burst;
                            completedProcess[i].Burst += process[i].Burst;
                            process[i].Burst = 0;
                        }
                        else
                        {
                            totalBtime += quantum;
                            process[i].Burst -= quantum;
                            completedProcess[i].Burst += quantum;
                        }

                        if (process[i].Burst < 1)
                        {
                            completedProcess[i].Turnaround += totalBtime;
                            totalTtime += completedProcess[i].Turnaround;
                            completedProcess[i].Waiting = completedProcess[i].Turnaround - completedProcess[i].Burst;
                            totalWtime += completedProcess[i].Waiting;
                        }
                    }
                    else
                    {
                        countCompleted++;
                    }
                }
            }

            //Finding average waiting & turnaround time
            avgWtime = (float)totalWtime / numOfProcess;
            avgTtime = (float)totalTtime / numOfProcess;

            //Printing result
            WriteLine("Process Burst Waiting Turnaround");
            for (i = 0; i < numOfProcess; i++)
            {
                WriteLine($"P-{i+1} \t {completedProcess[i].Burst} \t {completedProcess[i].Waiting} \t {completedProcess[i].Turnaround}");
            }
            WriteLine();
            WriteLine($"Average waiting time {avgWtime}");
            WriteLine($"Average turnaround time {avgTtime}");
        }
    }
}
