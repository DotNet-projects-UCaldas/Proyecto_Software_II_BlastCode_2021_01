using AppCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores
{
    public interface ClienteMapper<in T1, out T2>
    {
        public T2 MapFrom(T1 input);
    }
}
