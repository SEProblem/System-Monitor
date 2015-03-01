using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace SuperNonGenericNameForASystemMonitor
{
    class Program
    {
        /// <summary>
        /// Where all the magic happens!!!!!
        /// </summary>
        static void Main(string[] args)
        {
            #region Performance Counters
            // PerformanceCounter Foobar = new PerformanceCounter("", "");
            // PerformanceCounter Space
            PerformanceCounter PerfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total"); // CPU Usage Percentage
            PerformanceCounter PerfMemCount = new PerformanceCounter("Memory", "Available MBytes"); // Memory Available In MB
            PerformanceCounter PerfMemCount2 = new PerformanceCounter("Memory", "% Committed Bytes In Use"); // Memory: Committed Bytes
            PerformanceCounter TCPSent = new PerformanceCounter("TCPv4", "Segments Sent/sec"); // TCP Segments AKA Packets Sent
            PerformanceCounter TCPRecieved = new PerformanceCounter("TCPv4", "Segments Received/sec"); // TCP Segments AKA Packets Received
            PerformanceCounter TCPConnections = new PerformanceCounter("TCPv4", "Connections Active"); // Connections Active (To THE INTERNETZZZ)
            PerformanceCounter TCPSegments = new PerformanceCounter("TCPv4", "Segments/sec"); // Total Segments AKA Packets
            PerformanceCounter SYSUpTime = new PerformanceCounter("System", "System Up Time"); // How Long Has Your PC Been ON HMM!?!?!? (in seconds)
            #endregion

            #region Variables To Be Used In The INFINITY LOOP
            float Hour = 0.0f;
            float Min = 0.0f;
            float Sec = 0.0f;
            float Minn = 0.0f;
            float Hourr = 0.0f;
            float Minr = 0.0f;
            float HerpDerp = 0.0f;
            #endregion

            #region Infinite Loop That Sends Out ALL THE INFORMATION!!!
            // Infinite Loop
            while (true)
            {
                HerpDerp = SYSUpTime.NextValue();
                #region Time Conversion
                //This Is Where The Time Conversions Go
                Minn = HerpDerp / 60;
                Hourr = Minn / 60;
                Hour = (int)Hourr;
                Minr = Minn % 60;
                Min = (int)Minr;
                Sec = HerpDerp % 60;

                #endregion

                // Write All The INFORMATION! :DDDDDDDDD
                // BTW The Horrible Spacing At The End Is So That The When A Smaller Number Appears After A Larger One,
                // The Program Writes Over Any Values That Would Normally Not Be Overwritten... Simply, It's To Stop Artifacts
                // Also FYI Console.Clear() Will Flicker The Screen, While Console.SetCursorPosition(0,0) Doesn't...
                Console.WriteLine("System Up Time: {0}hr {1}min {2}sec     \n", Hour, Min, Sec);
                Console.WriteLine("CPU Load: {0}%                \n", PerfCpuCount.NextValue());
                Console.WriteLine("Memory Load:  {0}%            ", PerfMemCount2.NextValue());
                Console.WriteLine("Memory Usage: {0}MB           \n", PerfMemCount.NextValue());
                Console.WriteLine("Active Connections: {0}                ", TCPConnections.NextValue());
                Console.WriteLine("Packets Sent:       {0}/sec            ", TCPSent.NextValue());
                Console.WriteLine("Packets Received:   {0}/sec            ", TCPRecieved.NextValue());
                Console.WriteLine("Total # of Packets: {0}/sec            ", TCPSegments.NextValue());
                // Sleep Then Clear Console
                Thread.Sleep(1000);
                Console.SetCursorPosition(0,0);
            #endregion
            }
        }
    }
}
