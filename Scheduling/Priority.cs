using static System.Console;

namespace OsAlgo.Scheduling
{
    public class Priority
    {
        //Experimenting Priority Scheduling
        public static void Calculate()
        {
            Proc[] process;
            Proc temp;
            int i,j,totalWtime=0, totalBtime=0, totalTtime=0;
            float avgWtime, avgTtime;
            Write("Enter the number of process: ");
            int numOfProcess = int.Parse(ReadLine());
            process = new Proc[numOfProcess];

            
            for(i=0; i<numOfProcess; i++)
            {
                //Taking process input
                Proc p = new Proc();
                p.PID = i + 1;
                Write($"P-{i + 1} burst time: ");
                p.Burst = int.Parse(ReadLine());
                Write($"P-{i + 1} priority: ");
                p.Priority = int.Parse(ReadLine());
                WriteLine();

                //Sort by priority using insertion sort
                for (j=0; j<i; j++)
                {
                    if (process[j].Priority > p.Priority)
                    {
                        temp = process[j];
                        process[j] = p;
                        p = temp;
                    }
                }
                process[i] = p;
            }
            
            //Finding turnaround and waiting time
            for(i=0; i<numOfProcess; i++)
            {
                totalBtime += process[i].Burst;
                process[i].Turnaround = totalBtime;
                totalTtime += process[i].Turnaround;
                process[i].Waiting = process[i].Turnaround - process[i].Burst;
                totalWtime += process[i].Waiting;
            }
            avgTtime = (float)totalTtime / numOfProcess;
            avgWtime = (float)totalWtime / numOfProcess;

            //Printing result
            WriteLine("Process Burst Waiting Turnaround");
            for (i = 0; i < numOfProcess; i++)
            {
                WriteLine($"P-{process[i].PID} \t {process[i].Burst} \t {process[i].Waiting} \t {process[i].Turnaround}");
            }
            WriteLine();
            WriteLine($"Average waiting time {avgWtime}");
            WriteLine($"Average turnaround time {avgTtime}");
        }

        struct Proc {
            public int PID;
            public int Burst;
            public int Priority;
            public int Waiting;
            public int Turnaround;
        }

    }

   
}
