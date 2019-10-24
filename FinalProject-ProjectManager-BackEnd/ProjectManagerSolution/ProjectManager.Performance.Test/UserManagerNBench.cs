using NBench;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Test;

namespace ProjectManager.Performance.Test
{
    public class UserServiceNBench
    {
        private Counter _counter;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("UserTestCounter");
        }

        [PerfBenchmark(Description = "Test to ensure the performance parameters of Getuser API",
            NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterMeasurement("UserTestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.GreaterThanOrEqualTo, 0.0d)]
        public void GetAllUserPrefTest()
        {
            var userTest = new UserServiceTest();
            userTest.SetUp();
            userTest.GetAllUser();

            _counter.Increment();
        }

        [PerfBenchmark(Description = "Test to ensure the performance parameters of Get user By id API",
            NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterMeasurement("UserTestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.GreaterThanOrEqualTo, 0.0d)]
        public void GetUserPerformTest()
        {
            var userTest = new UserServiceTest();
            userTest.SetUp();
            userTest.GetUser();

            _counter.Increment();
        }

    }
}
