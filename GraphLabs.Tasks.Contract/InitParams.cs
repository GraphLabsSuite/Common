namespace GraphLabs.Tasks.Contract
{
    /// <summary> Параметры инициализации модуля-задания </summary>
    public class InitParams
    {
        public long TaskId { get; set; }
        public long? VariantId { get; set; }
        public long LabId { get; set; }

        private InitParams(long taskId, long? variantId, long labId)
        {
            TaskId = taskId;
            VariantId = variantId;
            LabId = labId;
        }

        /// <summary> Чтобы сериализация работала </summary>
        public InitParams()
        {
        }

        /// <summary> Для контрольного режима </summary>
        public InitParams ForControlMode(long taskId, long labId)
        {
            return new InitParams(taskId, null, labId);
        }

        /// <summary> Для ознакомительного режима </summary>
        public InitParams ForDemoMode(long taskId, long variantId, long labId)
        {
            return new InitParams(taskId, variantId, labId);
        }
    }
}