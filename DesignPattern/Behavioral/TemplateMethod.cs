using System;

namespace ScientificTemplateMethodDemo
{
    // AbstractClass: định nghĩa khuôn mẫu cho quy trình phân tích mẫu thí nghiệm
    abstract class LabSampleAnalyzer
    {
        public void AnalyzeSample()
        {
            ReceiveSample();
            PrepareSample();
            PerformAnalysis();
            OptionalHook1();
            RecordResults();
            CleanUp();
            OptionalHook2();
        }

        // Các bước có sẵn chung cho tất cả mẫu
        protected void ReceiveSample()
        {
            Console.WriteLine("Lab: Nhận mẫu từ bộ phận tiếp nhận...");
        }

        protected void RecordResults()
        {
            Console.WriteLine("Lab: Ghi lại kết quả phân tích vào hệ thống...");
        }

        protected void CleanUp()
        {
            Console.WriteLine("Lab: Vệ sinh thiết bị sau khi phân tích...");
        }

        // Các bước cần được triển khai bởi lớp con
        protected abstract void PrepareSample();
        protected abstract void PerformAnalysis();

        // Các hook – có thể override để tùy chỉnh
        protected virtual void OptionalHook1() { }
        protected virtual void OptionalHook2() { }
    }

    // ConcreteClass 1: Phân tích mẫu DNA
    class DNASampleAnalyzer : LabSampleAnalyzer
    {
        protected override void PrepareSample()
        {
            Console.WriteLine("DNA Lab: Ly giải tế bào và tách chiết DNA...");
        }

        protected override void PerformAnalysis()
        {
            Console.WriteLine("DNA Lab: Thực hiện PCR để khuếch đại đoạn gen...");
        }
    }

    // ConcreteClass 2: Phân tích mẫu nước
    class WaterSampleAnalyzer : LabSampleAnalyzer
    {
        protected override void PrepareSample()
        {
            Console.WriteLine("Water Lab: Lọc và đo pH mẫu nước...");
        }

        protected override void PerformAnalysis()
        {
            Console.WriteLine("Water Lab: Đo hàm lượng kim loại nặng bằng phương pháp quang phổ...");
        }

        protected override void OptionalHook1()
        {
            Console.WriteLine("Water Lab: Kiểm tra độ đục như một bước bổ sung.");
        }
    }

    class Scientist
    {
        public static void ProcessSample(LabSampleAnalyzer analyzer)
        {
            analyzer.AnalyzeSample();
        }
    }
}