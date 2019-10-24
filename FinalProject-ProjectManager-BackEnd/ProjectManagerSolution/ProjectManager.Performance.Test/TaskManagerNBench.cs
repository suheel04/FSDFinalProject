using NBench;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Test;

namespace ProjectManager.Performance.Test
{
    public class TaskServiceNBench
    {
        private Counter _counter;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TaskTestCounter");
        }

        [PerfBenchmark(Description = "Test to ensure the performance parameters of GetTasks API",
            NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterMeasurement("TaskTestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.GreaterThanOrEqualTo, 0.0d)]
        public void GetAllTaskPrefTest()
        {
            var tasksTest = new TaskServiceTest();
            tasksTest.SetUp();
             tasksTest.GetAllTask();

            _counter.Increment();
        }

        [PerfBenchmark(Description = "Test to ensure the performance parameters of GetTaskById API",
            NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterMeasurement("TaskTestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.GreaterThanOrEqualTo, 0.0d)]
        public void GetTaskPerformTest()
        {
            var tasksTest = new TaskServiceTest();
            tasksTest.SetUp();
             tasksTest.GetTask();

            _counter.Increment();
        }

    }
}
