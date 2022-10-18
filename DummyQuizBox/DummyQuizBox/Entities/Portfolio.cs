using System;

namespace DummyQuizBox.Entities
{
    public class Portfolio
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
