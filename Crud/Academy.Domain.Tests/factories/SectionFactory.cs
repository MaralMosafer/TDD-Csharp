﻿namespace Academy.Domain.Tests.factories
{

    public class SectionFactory
    {
        public static Section Create()
        {
            return new Section(1, "Why We Write Tests");
        }
    }

}