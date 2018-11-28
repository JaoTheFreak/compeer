using System;

namespace Compeer.Core.Entities
{
    public class Queue
    {
        public int Id { get; set; }

        public string QueueName { get; set; }

        public int QueuePvpDenominator { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}