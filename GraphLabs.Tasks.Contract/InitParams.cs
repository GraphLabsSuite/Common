using System;

namespace GraphLabs.Tasks.Contract
{
    /// <summary> Параметры инициализации модуля-задания </summary>
    public class InitParams
    {
        public long TaskId { get; set; }
        public long? VariantId { get; set; }
        public long LabId { get; set; }
        public Guid SessionGuid { get; set; }

        private InitParams(long taskId, long? variantId, long labId, Guid sessionGuid)
        {
            TaskId = taskId;
            VariantId = variantId;
            LabId = labId;
            SessionGuid = sessionGuid;
        }

        /// <summary> Чтобы сериализация работала </summary>
        public InitParams()
        {
        }

        /// <summary> Для контрольного режима </summary>
        public static InitParams ForControlMode(Guid sessionGuid, long taskId, long labId)
        {
            return new InitParams(taskId, null, labId, sessionGuid);
        }

        /// <summary> Для ознакомительного режима </summary>
        public static InitParams ForDemoMode(Guid sessionGuid, long taskId, long variantId, long labId)
        {
            return new InitParams(taskId, variantId, labId, sessionGuid);
        }
    }
}