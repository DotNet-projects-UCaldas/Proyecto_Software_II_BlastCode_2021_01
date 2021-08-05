using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Mapeadores.Abstract
{
    /// <summary>
    /// Clase abstracta que se emplea en los mapeadores
    /// </summary>
    /// <typeparam name="T1">El tipo que ingresa para ser mapeado</typeparam>
    /// <typeparam name="T2">El tipo mapeado</typeparam>
    public abstract class MapperBase<T1, T2>
    {
        public abstract T2 mapearT1T2(T1 entrada);
        public abstract T1 mapearT2T1(T2 entrada);

        public abstract List<T2> mapearT1T2(List<T1> entrada);
        public abstract List<T1> mapearT2T1(List<T2> entrada);
    }
}