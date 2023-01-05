using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Struktury;

internal struct Dog
{
    private string _name;
    private string _owner;

    public void SetOwner(string owner)
    {
        _owner = owner;
    }

    public string GetOwner()
    {
        return _owner;
    }
}