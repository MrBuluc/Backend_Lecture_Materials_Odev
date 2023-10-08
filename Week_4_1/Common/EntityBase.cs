﻿namespace Week_4_1.Common
{
    public class EntityBase<TKey>
    {
        public TKey Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public EntityBase(TKey ıd, DateTimeOffset createdOn)
        {
            Id = ıd;
            CreatedOn = createdOn;
        }
    }
}
