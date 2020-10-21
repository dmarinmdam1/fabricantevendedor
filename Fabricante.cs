
using System.Threading;

namespace fabricantevendedor
{
    public class Fabricante
    {
        private Almacen almacen;
        private Thread thread;
        private uint periodicidad;
        private uint cantidad;

        public Fabricante(Almacen _almacen, uint _periodicidad, uint _cantidad)
        {
            this.almacen = _almacen;
            this.periodicidad = _periodicidad;
            this.cantidad = _cantidad;
        }

        public void Fabrica()
        {
            thread = new Thread(() => _Accion());
            thread.Start();
        }

        public void Termina()
        {
            thread.Join();
        }

        private void _Accion()
        {
            for(uint i = 0 ; i < cantidad ; i++)
            {
                Thread.Sleep((int)periodicidad);
                almacen.Guardar();
            }
        }
    }
}
