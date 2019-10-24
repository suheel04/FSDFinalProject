using NBench;
using System;
using System.Collections.Generic;
using ProjectManager.Test;

namespace ProjectManager.Performance.Test
{
    public class ProjectServiceNBench
    {
        private Counter _counter;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("ProjectTestCounter");
        }

        [PerfBenchmark(Description = "Test to ensure the performance parameters of Get Project API",
            NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterMeasurement("ProjectTestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.GreaterThanOrEqualTo, 0.0d)]
        public void GetAllProjectPrefTest()
        {
            var ProjectsTest = new ProjectServiceTest();
            ProjectsTest.SetUp();
             ProjectsTest.GetAllProject();

            _counter.Increment();
        }

        [PerfBenchmark(Description = "Test to ensure the performance parameters of Get Project by id API",
            NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterMeasurement("ProjectTestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.GreaterThanOrEqualTo, 0.0d)]
        public void GetProjectPerformTest()
        {
            var ProjectsTest = new ProjectServiceTest();
            ProjectsTest.SetUp();
             ProjectsTest.GetProject();

            _counter.Increment();
        }

    }
}
