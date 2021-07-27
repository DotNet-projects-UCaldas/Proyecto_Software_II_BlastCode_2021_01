using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores.Abstract
{
    public abstract class MapperVenta<T1, T2>
    {
        public abstract T2 mapearT1T2(T1 entrada);
        public abstract T1 mapearT2T1(T2 entrada);

        public abstract IEnumerable<T2> mapearT1T2(IEnumerable<T1> entrada);
        public abstract IEnumerable<T1> mapearT2T1(IEnumerable<T2> entrada);
    }
}
