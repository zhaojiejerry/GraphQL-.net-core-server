using GraphDemo.Orders.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo.Orders.Schema
{
    public class UserType: ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
